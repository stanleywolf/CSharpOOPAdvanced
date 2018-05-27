using System;
using NUnit.Framework;

namespace SkeletonTests
{
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            var axe = new Axe(5,10);
            var dummy = new Dummy(20,20);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints,Is.EqualTo(9));
        }
        [Test]
        public void BrokenAxeCannotAttack()
        {
            var axe = new Axe(5, 0);
            var dummy = new Dummy(20, 20);
            Assert.That(() => axe.Attack(dummy),Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
