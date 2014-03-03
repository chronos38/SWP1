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

#ifndef APPLICATION_HPP
#define APPLICATION_HPP

#include "Types.hpp"
#include "Singleton.hpp"
#include "ICommand.hpp"
#include <list>
#include <vector>

class Application : public Singleton<Application>
{
	friend class Singleton<Application>;
public:
	virtual ~Application();
	virtual void Execute();
	virtual int ExitCode() const;
	virtual CommandList GetCommands() const;
	static int GetArugment(const Args& args, const std::string& string);
	static int GetArgumentIndex(const Args& args, char arg);
protected:
	Application();
	Args CreateArguments(const std::string& buffer) const;
private:
	Commands mCommands;
};

#endif
