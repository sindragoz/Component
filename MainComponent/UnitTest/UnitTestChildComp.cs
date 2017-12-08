﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;

namespace UnitTest
{
    [TestClass]
    public class UnitTestChildComp
    {
        [TestMethod]
        public void TestAccessory()
        {
            var childComponent = new ChildComponent.ChildComponent();

            childComponent.Accessory = true;

            Assert.AreEqual(true, childComponent.Accessory);
        }

        [TestMethod]
        public void TestOnPrimaryComp()
        {
            var childComponent = new ChildComponent.ChildComponent();

            childComponent.OnPrimaryComponent = true;

            Assert.AreEqual(true, childComponent.OnPrimaryComponent);
        }

        [TestMethod]
        public void TestRandomLocation()
        {
            var childComponent = new ChildComponent.ChildComponent();

            childComponent.RandomLocation = true;

            Assert.AreEqual(false, childComponent.RandomLocation);
        }

        //[TestMethod]
        //public void TestNewPoint()
        //{
        //    var childComponent = new ChildComponent.ChildComponent();

        //    var res = childComponent.newPoint();

        //    Assert.AreNotEqual(new Point(0,0), res);
        //}


    }
}
