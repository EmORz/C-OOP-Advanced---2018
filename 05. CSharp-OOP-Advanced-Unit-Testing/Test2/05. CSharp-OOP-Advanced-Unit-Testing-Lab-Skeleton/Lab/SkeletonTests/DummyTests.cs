using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Skeleton;

namespace SkeletonTests
{
    public class DummyTests
    {

        private ITarget dummy;


        [Test]
        //•	Dummy loses health if attacked
        public void DymmyLoosesHealthIfAttacked()
        {
            dummy = new Dummy(10, 15);
            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5), "Dummy doesnt lose health if attacked");
        }


        [Test]
        //•	Dead Dummy throws an exception if attacked
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            dummy = new Dummy(0, 15);

            Assert.That(() => dummy.TakeAttack(5),Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), 
                "Dead Dummy doesnt throw invalidoperation exception! ");
        }
        //•	Dead Dummy can give XP
        [Test]
        public void DeadDummyCanGiveExpirence()
        {
            var hero = new Hero("Pesho");
             dummy = new Dummy(10, 50);
           
            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(50), "Dead Dummy cant give expirience");
        }


        //•	Alive Dummy can't give XP
        [Test]
        public void AliveDummyCantGiveExpirience()
        {
            var hero = new Hero("Pesho");
            dummy = new Dummy(20, 50);

            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(0), "Alive Dummy cant give ");
        }

    }
}