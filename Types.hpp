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

#ifndef TYPES_HPP
#define TYPES_HPP

#include <string>
#include <map>
#include <list>
#include <vector>
class ICommand;

enum class ClockOperationFlags {
	None = 0,
	Seconds = 0x1,
	Minutes = 0x2,
	Hours = 0x4
};

enum class ClockType {
	Analog,
	Digital,
	AnalogLive,
	DigitalLive
};

static const int BUFFER_LENGTH = 1024;

static const int WINDOW_WIDTH = 256;
static const int WINDOW_HEIGHT = 256;

typedef std::string Arg;
typedef std::vector<std::string> Args;

typedef std::map<std::string, ICommand*> Commands;
typedef std::list<ICommand*> CommandList;

static const std::string SET = "SET";
static const std::string INC = "INC";
static const std::string DEC = "DEC";
static const std::string UNDO = "UNDO";
static const std::string REDO = "REDO";
static const std::string SHOW = "SHOW";
static const std::string HELP = "HELP";
static const std::string RESET = "RESET";

#endif
