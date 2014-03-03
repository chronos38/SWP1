/* Copyright © 2014 David Wolf <d.wolf@live.at>
 *
 * This file is part of SWP1.
 *
 * SWP1 is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SWP1 is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SWP1.  If not, see <http://www.gnu.org/licenses/>.
 */

#include "Application.hpp"
#include "Clock.hpp"
#include "CommandSet.hpp"
#include "CommandIncrement.hpp"
#include "CommandDecrement.hpp"
#include "CommandUndo.hpp"
#include "CommandRedo.hpp"
#include "CommandShow.hpp"
#include "CommandHelp.hpp"
#include "CommandReset.hpp"
#include "Painter.hpp"
#include "ClockWindow.hpp"
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <iostream>
#include <string>
#include <sstream>
#include <algorithm>
#include <iterator>
#include <chrono>
#include <cstdlib>
#include <cctype>

Application::Application()
{
	// set commands
	mCommands[SET] = new CommandSet();
	mCommands[INC] = new CommandIncrement();
	mCommands[DEC] = new CommandDecrement();
	mCommands[UNDO] = new CommandUndo();
	mCommands[REDO] = new CommandRedo();
	mCommands[SHOW] = new CommandShow();
	mCommands[HELP] = new CommandHelp();
	mCommands[RESET] = new CommandReset();

	// initialize sdl
	if (SDL_Init(SDL_INIT_EVERYTHING) != 0) {
		throw std::exception(SDL_GetError());
	} else if (TTF_Init() != 0) {
		throw std::exception(TTF_GetError());
	}

	// initialize painter
	Painter::Initialize();

	// initialize future
	mThread = std::async(std::launch::async, [] ()->std::string {
		return "";
	});
}

Application::~Application()
{
	// dispose painter
	Painter::Dispose();

	// quit sdl
	SDL_Quit();
	TTF_Quit();
}

void Application::Execute()
{
	// variables
	char buffer[BUFFER_LENGTH];
	std::string string = "";

	// set buffer 
	memset(buffer, 0, BUFFER_LENGTH);

	// first output
	std::cout << "Enter 'HELP' for further information." << std::endl;

	while (true) {
		std::cout << "Input: ";
		std::cin >> string;

		// check for arguments
		if (std::cin.eof()) {
			std::cin.ignore();
		}

		// case insensitive buffer
		std::transform(string.begin(), string.end(), string.begin(), ::toupper);

		// find command
		auto it = mCommands.find(string);

		if (string == "") {
			continue;
		} else if (string == "EXIT") {
			break;
		} else if (it != mCommands.end()) {
			// read arguments
			std::cin.getline(buffer, BUFFER_LENGTH - 1, '\n');
			// execute command
			it->second->Execute(CreateArguments(buffer));
			// clear buffer
			memset(buffer, 0, BUFFER_LENGTH);
			// update changes
			Clock::GetInstance().Notify();
		} else {
			std::cout << "Unknown command." << std::endl;
		}

		// check for SDL events
		if (SDL_HasEvent(SDL_WINDOWEVENT) == SDL_FALSE) {
			ProcessEvents();
		}

		string = "";
	}
}

int Application::ExitCode() const
{
	// return success
	return (EXIT_SUCCESS);
}

CommandList Application::GetCommands() const
{
	CommandList list;

	for (auto& it : mCommands) {
		list.push_back(it.second);
	}

	return list;
}

Args Application::CreateArguments(const std::string& buffer) const
{
	// variables
	std::string string = buffer;
	std::istringstream iss;
	Args args;

	// case insensitive buffer
	std::transform(string.begin(), string.end(), string.begin(), ::toupper);
	iss = std::istringstream(string);

	// result
	std::copy(std::istream_iterator<std::string>(iss),
		  std::istream_iterator<std::string>(),
		  std::back_inserter<Args>(args));

	return args;
}

int Application::GetArgument(const Args& args, const std::string& string)
{
	for (auto& it : args) {
		if (it[0] != '-' || it.size() != 2) {
			continue;
		}

		for (auto& ch : string) {
			auto& find = std::find(it.begin(), it.end(), ch);

			if (find != it.end()) {
				return (*find);
			}
		}
	}

	return -1;
}

int Application::GetArgumentIndex(const Args& args, char arg)
{
	std::string string = ('-' + std::string(1, arg));

	for (unsigned i = 0; i < args.size(); i++) {
		if (args[i] == string) {
			return i;
		}
	}

	return -1;
}

void Application::ProcessEvents()
{
	// variables
	SDL_Event event;

	// poll event queue
	while (true) {
		if (!SDL_PollEvent(&event)) {
			break;
		} else if (event.type != SDL_WINDOWEVENT) {
			continue;
		}

		if (event.window.type == SDL_WINDOWEVENT_CLOSE) {
			IObserver* observer = Clock::GetInstance().FindObserverFromWindow(event.window.windowID);

			if (observer) {
				delete observer;
			}
		}
	}
}
