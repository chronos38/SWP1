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

#include "Clock.hpp"
#include <exception>
#include <ctime>

Clock::Clock()
{
	try {
		// variables
		time_t t = time(nullptr);
		tm* utc = gmtime(&t);

		// check for error
		if (!utc) {
			throw std::exception("couldn't create utc time");
		}

		// set values
		mSeconds = utc->tm_sec;
		mMinutes = utc->tm_min;
		mHours = utc->tm_hour;

		// check seconds
		if (mSeconds >= 60) {
			mSeconds = 0;
			mMinutes += 1;
		}

		// check minutes
		if (mMinutes >= 60) {
			mMinutes = 0;
			mHours += 1;
		}

		// check hours
		if (mHours >= 24) {
			mHours = 0;
		}
	} catch (...) {
		std::rethrow_exception(std::current_exception());
	}
}

void Clock::Attach(IObserver* observer)
{
	mObserver.push_back(observer);
}

void Clock::Detach(IObserver* observer)
{
	mObserver.remove(observer);
}

void Clock::Notify()
{
	for (auto& it : mObserver) {
		it->Update(this);
	}
}

void Clock::Set(int h, int m, int s)
{
	// push current values and clear redo buffer
	mUndoBuffer.push(CreateOperation());
	mRedoBuffer = OperationQueue();

	// set new values
	if (h != -1) mHours = h;
	if (m != -1) mMinutes = m;
	if (s != -1) mSeconds = s;
}

void Clock::Increment(ClockOperationFlags flags)
{
	// push current values and clear redo buffer
	mUndoBuffer.push(CreateOperation());
	mRedoBuffer = OperationQueue();

	// increment values

	if (((int)flags & (int)ClockOperationFlags::Seconds) != 0) {
		(mSeconds < 59) ? mSeconds++ : mSeconds = 0, mMinutes++;
	}

	if (((int)flags & (int)ClockOperationFlags::Minutes) != 0) {
		(mMinutes < 59) ? mMinutes++ : mMinutes = 0, mHours++;
	}

	if (((int)flags & (int)ClockOperationFlags::Hours) != 0) {
		(mHours < 23) ? mHours++ : mHours = 0, mMinutes = 0, mSeconds = 0;
	}
}

void Clock::Decrement(ClockOperationFlags flags)
{
	// push current values and clear redo buffer
	mUndoBuffer.push(CreateOperation());
	mRedoBuffer = OperationQueue();

	// decrement values

	if (((int)flags & (int)ClockOperationFlags::Seconds) != 0) {
		(mSeconds > 0) ? mSeconds-- : mSeconds = 59, mMinutes--;
	}

	if (((int)flags & (int)ClockOperationFlags::Minutes) != 0) {
		(mMinutes > 0) ? mMinutes-- : mMinutes = 59, mHours--;
	}

	if (((int)flags & (int)ClockOperationFlags::Hours) != 0) {
		(mHours > 0) ? mHours-- : mHours = 23, mMinutes = 59, mSeconds = 59;
	}
}

void Clock::Undo()
{
	// get previous operation
	Operation operation = mUndoBuffer.back();

	// push into redo buffer
	mRedoBuffer.push(operation);

	// set values
	mHours = std::get<0>(operation);
	mMinutes = std::get<1>(operation);
	mSeconds = std::get<2>(operation);
}

void Clock::Redo()
{
	// check buffer
	if (mRedoBuffer.empty()) {
		return;
	}

	// get previous operation
	Operation operation = mRedoBuffer.back();

	// push into redo buffer
	mUndoBuffer.push(operation);

	// set values
	mHours = std::get<0>(operation);
	mMinutes = std::get<1>(operation);
	mSeconds = std::get<2>(operation);
}

void Clock::Reset()
{
	(*this) = Clock();
}

int Clock::Seconds() const
{
	return mSeconds;
}

int Clock::Minutes() const
{
	return mMinutes;
}

int Clock::Hours() const
{
	return mHours;
}

Clock::Operation Clock::CreateOperation() const
{
	return std::make_tuple(mHours, mMinutes, mSeconds);
}
