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

#include "DigitalClock.hpp"
#include "Clock.hpp"
#include "Painter.hpp"
#include <SDL2/SDL.h>
#include <cstdio>

DigitalClockWindow::DigitalClockWindow(int x, int y)
{
	Initialize("Digital Clock", x, y);
}

DigitalClockWindow::~DigitalClockWindow()
{
	Dispose();
}

void DigitalClockWindow::Update(ISubject* subject)
{
	// variables
	mClock = dynamic_cast<Clock*>(subject);
}

void DigitalClockWindow::Draw()
{
	// variables
	char buffer[9];
	Painter painter(this);

	// set buffer
	memset(buffer, 0, sizeof(buffer));
	sscanf(buffer, "%02d:%02d:%02d", mClock->Hours(), mClock->Minutes(), mClock->Seconds());

	// draw text
	painter.DrawText({ 0, 0 }, buffer, { 0, 255, 0, 0 });
}
