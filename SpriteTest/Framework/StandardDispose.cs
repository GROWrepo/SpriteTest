﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteTest
{
	public class StandardDispose : IDisposable
	{
		protected bool IsAlreadyDisposed { get; private set; } = false;

		~StandardDispose () { Dispose ( false ); }

		public virtual void Dispose ()
		{
			if ( IsAlreadyDisposed )
				return;

			Dispose ( true );
			GC.SuppressFinalize ( this );
		}

		protected virtual void Dispose ( bool disposing )
		{
			IsAlreadyDisposed = true;
		}

		protected void AssertDisposed ()
		{
			if ( IsAlreadyDisposed )
				throw new ObjectDisposedException ( GetType ().Name );
		}
	}
}
