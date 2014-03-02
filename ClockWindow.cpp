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

#include "ClockWindow.hpp"
#include "Clock.hpp"
#include <SDL2/SDL.h>
#include <exception>

ClockWindow::ClockWindow()
{
	Initialize("Default Clock");
}

ClockWindow::~ClockWindow()
{
	Dispose();
}

void ClockWindow::Initialize(const char* title, int x, int y)
{
	// create window
	CreateWindow(title, x, y);

	// attach to subject
	Clock::GetInstance().Attach(this);
}

void ClockWindow::Update(ISubject* subject)
{
	// do nothing
}

void ClockWindow::Draw()
{
	// present current renderer
	SDL_RenderPresent(mRenderer);

	// set black as drawing color
	SDL_SetRenderDrawColor(mRenderer, 0, 0, 0, 255);

	// clear renderer
	SDL_RenderClear(mRenderer);
}

void ClockWindow::Dispose()
{
	// detach from subject
	Clock::GetInstance().Detach(this);

	// delete renderer
	if (mRenderer) {
		SDL_DestroyRenderer(mRenderer);
		mRenderer = nullptr;
	}
	
	// delete window
	if (mWindow) {
		SDL_DestroyWindow(mWindow);
		mWindow = nullptr;
	}
}

bool ClockWindow::IsDisposed() const
{
	return (mWindow == nullptr || mRenderer == nullptr);
}

SDL_Renderer* ClockWindow::Renderer()
{
	return mRenderer;
}

bool ClockWindow::CreateWindow(const char* title, int x, int y)
{

	// create window
	mWindow = SDL_CreateWindow(title,
				   x == -1 ? SDL_WINDOWPOS_UNDEFINED : x,
				   y == -1 ? SDL_WINDOWPOS_UNDEFINED : y,
				   WINDOW_WIDTH,
				   WINDOW_HEIGHT,
				   SDL_WINDOW_SHOWN | SDL_WINDOW_OPENGL);

	// check if window is a nullptr
	if (!mWindow) {
		return false;
	}

	// create renderer
	mRenderer = SDL_CreateRenderer(mWindow,
				       -1,
				       SDL_RENDERER_SOFTWARE | SDL_RENDERER_PRESENTVSYNC);

	// check if renderer is a nullptr
	if (!mRenderer) {
		return false;
	}

	return true;
}
