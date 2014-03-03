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
#include <string>

struct SDL_Point;
struct SDL_Color;
struct SDL_Rect;
struct _TTF_Font;

class Painter
{
public:
	Painter(IDrawable* drawable);
	virtual ~Painter();
	virtual void DrawPoint(const SDL_Point& position, const SDL_Color& color);
	virtual void DrawLine(const SDL_Point& position, const SDL_Point& endPosition, const SDL_Color& color);
	virtual void DrawRectangle(const SDL_Rect& rect, const SDL_Color& color);
	virtual void DrawCircle(const SDL_Point& position, int radius, const SDL_Color& color);
	virtual void DrawText(const SDL_Point& position, const std::string& text, const SDL_Color& color);
protected:
	static void Initialize();
	static void Dispose();
	static bool IsDisposed();
private:
	static _TTF_Font* sFont;
	IDrawable* mDrawable = nullptr;
};

#endif
