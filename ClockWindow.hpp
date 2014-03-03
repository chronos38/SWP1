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

#ifndef CLOCKWINDOW_HPP
#define CLOCKWINDOW_HPP

#include "IObserver.hpp"
#include "IDrawable.hpp"

class Application;
struct SDL_Window;
struct SDL_Renderer;

class ClockWindow : public IObserver, public IDrawable
{
	friend class Application;
public:
	ClockWindow();
	virtual ~ClockWindow();
	virtual void Initialize(const char* title, int x = -1, int y = -1);
	virtual void Draw() override;
	virtual void Dispose();
	virtual bool IsDisposed() const;
	virtual SDL_Renderer* Renderer() override;
	virtual int GetID() const;
private:
	virtual bool CreateWindow(const char* title, int x = -1, int y = -1);
private:
	SDL_Window* mWindow = nullptr;
	SDL_Renderer* mRenderer = nullptr;
};

#endif
