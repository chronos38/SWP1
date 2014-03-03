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

#ifndef DIGITALCLOCKWINDOW_HPP
#define DIGITALCLOCKWINDOW_HPP

#include "ClockWindow.hpp"

class DigitalClockWindow : public ClockWindow
{
public:
	DigitalClockWindow(int timezone, int x, int y);
	virtual ~DigitalClockWindow();
	virtual void Update(ISubject* subject) override;
	virtual void Draw() override;
private:
	bool mUpdate = false;
	int mTimezone = 0;
};

#endif
