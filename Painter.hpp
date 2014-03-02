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

#ifndef PAINTER_HPP
#define PAINTER_HPP

#include "IDrawable.hpp"

class Painter
{
public:
	Painter(IDrawable* drawable);
	virtual ~Painter();
	virtual void DrawPoint();
	virtual void DrawLine();
	virtual void DrawRectangle();
	virtual void DrawCircle();
	virtual void DrawText();
private:
	IDrawable* mDrawable = nullptr;
};

#endif
