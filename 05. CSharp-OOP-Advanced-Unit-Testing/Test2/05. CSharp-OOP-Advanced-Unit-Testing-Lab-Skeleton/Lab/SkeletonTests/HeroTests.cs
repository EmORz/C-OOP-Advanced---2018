using NUnit.Framework;
using Skeleton;

namespace SkeletonTests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void TestHeroGainXp()
        {
            IWeapon fakeWeapon = new FakeWeapon();
            ITarget fakeTarget = new FakeTarget();

            Hero hero = new Hero("Peshko", fakeWeapon);

            hero.Attack(fakeTarget);

            var actualResult = hero.Experience;
            var expectResult = 10;

            Assert.AreEqual(expectResult, actualResult);
        }
        

    }
}