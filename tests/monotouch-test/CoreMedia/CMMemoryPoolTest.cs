//
// Unit tests for CMMemoryPool
//
// Authors:
//	Marek Safar (marek.safar@gmail.com)
//
// Copyright 2012 Xamarin Inc All rights reserved.
//

#if !__WATCHOS__

using System;
#if XAMCORE_2_0
using Foundation;
using UIKit;
using CoreMedia;
#else
using MonoTouch.Foundation;
using MonoTouch.CoreMedia;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.CoreMedia {
	
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class CMMemoryPoolTest
	{
		[Test]
		public void Ctor ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (6,0))
				Assert.Inconclusive ("EntryPointNotFoundException : CMMemoryPoolCreate before 6.0");

			using (var mp = new CMMemoryPool ())
			{
				var allocator = mp.GetAllocator ();
				var ptr = allocator.Allocate (55);
				Assert.AreNotEqual (IntPtr.Zero, ptr);
				allocator.Deallocate (ptr);
			}
		}

		[Test]
		public void CtorAgeOutPeriod ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (6,0))
				Assert.Inconclusive ("EntryPointNotFoundException : CMMemoryPoolCreate before 6.0");

			using (var mp = new CMMemoryPool (TimeSpan.FromSeconds (40)))
			{
				var allocator = mp.GetAllocator ();
				var ptr = allocator.Allocate (2);
				Assert.AreNotEqual (IntPtr.Zero, ptr);
				allocator.Deallocate (ptr);
			}
		}
	}
}

#endif // !__WATCHOS__
