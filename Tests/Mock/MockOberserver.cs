using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWP1;

namespace Tests.Mock
{
	class MockOberserver : IObserver
	{

		public bool UpdateOccured { get; set; }
		public void Update(ISubject subject)
		{
			UpdateOccured = true;
		}
	}
}
