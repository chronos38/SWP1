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

struct SDL_Window;
struct SDL_Renderer;
struct TTF_Font;

#endif
