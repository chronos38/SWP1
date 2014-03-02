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

#include "Painter.hpp"
#include <SDL2/SDL.h>
#include <SDL2/SDL_ttf.h>
#include <exception>

TTF_Font* Painter::sFont = nullptr;

Painter::Painter(IDrawable* drawable)
{
	if (!drawable) {
		throw std::exception("null pointer encountered, painter needs a valid drawable object");
	}

	mDrawable = drawable;
}

Painter::~Painter()
{
	// do nothing
}

void Painter::DrawPoint(const SDL_Point& position, const SDL_Color& color)
{
	// variables
	SDL_Renderer* renderer = mDrawable->Renderer();

	// set black as drawing color
	SDL_SetRenderDrawColor(renderer, color.r, color.g, color.b, 255);

	// draw point
	SDL_RenderDrawPoint(renderer, position.x, position.y);
}

void Painter::DrawLine(const SDL_Point& position, const SDL_Point& endPosition, const SDL_Color& color)
{
	// variables
	SDL_Renderer* renderer = mDrawable->Renderer();

	// set black as drawing color
	SDL_SetRenderDrawColor(renderer, color.r, color.g, color.b, 255);

	// draw line
	SDL_RenderDrawLine(renderer, position.x, position.y, endPosition.x, endPosition.y);
}

void Painter::DrawRectangle(const SDL_Rect& rect, const SDL_Color& color)
{
	// variables
	SDL_Renderer* renderer = mDrawable->Renderer();

	// set black as drawing color
	SDL_SetRenderDrawColor(renderer, color.r, color.g, color.b, 255);

	// draw line
	SDL_RenderDrawRect(renderer, &rect);
}

void Painter::DrawCircle(const SDL_Point& position, int radius, const SDL_Color& color)
{
	// TODO: add drawing logic
}

void Painter::DrawText(const SDL_Point& position, const char* text, const SDL_Color& color)
{
	// check font
	if (!sFont) {
		return;
	}

	// variables
	SDL_Surface* surface = nullptr;
	SDL_Rect srcrect, dstrect;
	SDL_Renderer* renderer = mDrawable->Renderer();

	// draw text
	surface = TTF_RenderText_Blended(sFont, text, color);

	// check surface
	if (!surface) {
		return;
	}

	// set rectangles
	srcrect = { 0, 0, surface->w, surface->h };
	dstrect = { position.x, position.y, surface->w, surface->h };

	// create texture
	SDL_Texture* texture = SDL_CreateTextureFromSurface(renderer, surface);

	// check texture
	if (!texture) {
		SDL_FreeSurface(surface);
		return;
	}

	// render texture
	SDL_RenderCopy(renderer, texture, &srcrect, &dstrect);

	// delete allocated memory
	SDL_FreeSurface(surface);
	SDL_DestroyTexture(texture);
}

void Painter::Initialize()
{
	sFont = TTF_OpenFont("Fonts/ATOMICCLOCKRADIO.TTF", 32);
}

void Painter::Dispose()
{
	if (sFont) TTF_CloseFont(sFont);
}

bool Painter::IsDisposed()
{
	return (sFont != nullptr);
}
