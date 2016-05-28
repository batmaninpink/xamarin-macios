//
// Unit tests for NSUuid
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2012-2013 Xamarin Inc. All rights reserved.
//

using System;
using System.IO;
#if XAMCORE_2_0
using Foundation;
using UIKit;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.Foundation {
	
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class UuidTest {
		
		[Test]
		public void Constructors ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (6,0))
				Assert.Inconclusive ("NSUUID is new in 6.0");

			var uuid = new NSUuid (new byte [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
			Assert.That (uuid, Is.Not.EqualTo (null), "constructed");

			var bytes = uuid.GetBytes ();
			Assert.That (bytes.Length, Is.EqualTo (16), "lenght");

			for (int i = 0; i < 16; i++)
				Assert.That (bytes [i], Is.EqualTo (i), "value " + i);
		}

		[Test]
		public void ConstructorFailures ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (6,0))
				Assert.Inconclusive ("NSUUID is new in 6.0");
			
			try {
				var uuid = new NSUuid ((byte[]) null);
				Assert.Fail ("Should have t;hrown an exception");
			} catch (ArgumentNullException) {
				// good
			} catch (Exception e){
				Assert.Fail ("Unexpected exception {0}", e);
			}
			
			try {
				var uuid = new NSUuid (new byte [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
				Assert.Fail ("Should have thrown an ArgumentException");
			} catch (ArgumentException){
				// ok
			} catch (Exception e){
				Assert.Fail ("Expected an ArgumentException {0}", e);
			}
		}
	}
}