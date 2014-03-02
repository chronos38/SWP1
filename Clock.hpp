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

#ifndef CLOCK_HPP
#define CLOCK_HPP

#include "Types.hpp"
#include "Singleton.hpp"
#include "IObserver.hpp"
#include <list>
#include <queue>
#include <tuple>

class Clock : public Singleton<Clock>, public ISubject
{
public:
	Clock(const Clock&) = delete;
	Clock(Clock&&) = delete;
	virtual ~Clock() = default;
	virtual void Attach(IObserver* observer) final;
	virtual void Detach(IObserver* observer) final;
	virtual void Notify() final;
	virtual void Set(int h = -1, int m = -1, int s = -1) final;
	virtual void Increment(ClockOperationFlags flags) final;
	virtual void Decrement(ClockOperationFlags flags) final;
	virtual void Undo() final;
	virtual void Redo() final;
	virtual void Reset() final;
	virtual int Seconds() const final;
	virtual int Minutes() const final;
	virtual int Hours() const final;
private:
	Clock();
private:
	typedef std::list<IObserver*> ObserverList;
	typedef std::tuple<int, int, int> Operation;
	typedef std::queue<Operation> OperationQueue;

	Operation CreateOperation() const;

	int mSeconds;
	int mMinutes;
	int mHours;

	ObserverList mObserver;
	OperationQueue mUndoBuffer;
	OperationQueue mRedoBuffer;
};

#endif
