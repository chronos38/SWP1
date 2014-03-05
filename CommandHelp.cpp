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

#include "CommandHelp.hpp"
#include "Application.hpp"
#include <iostream>

using namespace std;

void CommandHelp::Execute(const Args& args)
{
	// variables
	Application& app = Application::GetInstance();
	CommandList list = app.GetCommands();

	// show commands
	cout << "Commands are:\n";

	for (auto& it : list) {
		cout << "\t" << it->Name() << "\n";
		cout << it->Help() << "\n";
	}
	
	cout << "\tEXIT" << endl;
}

const char* CommandHelp::Name() const
{
	return HELP.c_str();
}

const char* CommandHelp::Help() const
{
	return "";
}
