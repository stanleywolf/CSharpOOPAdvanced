using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace SkeletonTests
{
   public class HeroTests
    {
        [Test]
        public void HeroGiansExAfterAttackIfTargetDies()
        {
            var experienceGaint = 5;
            var target = new Mock<ITarget>();

            target.Setup(t => t.IsDead()).Returns(true);

            target.Setup(t => t.GiveExperience()).Returns(experienceGaint);

            var weapon = new Mock<IWeapon>();
            
            var hero = new Hero("Stancho",weapon.Object);

            hero.Attack(target.Object);

            weapon.Verify(w => w.Attack(target.Object));

            Assert.That(hero.Experience,Is.EqualTo(experienceGaint));
        }
    }
}
