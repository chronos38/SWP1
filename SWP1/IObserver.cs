﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP1
{
	public interface IObserver
	{
		void Update(ISubject subject);
	}
}
