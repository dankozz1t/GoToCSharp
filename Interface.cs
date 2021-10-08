using System.Collections.Generic;

namespace GoToCSharp
{
    public interface IWorker
    {
        void Work();
    }

    public interface IManager
    {
        List<IWorker> Workers { get; set; }
        void Planing();
        void Control();
    }


    public interface IA
    {
        void A();
    }

    public interface IB
    {
        int B1(int b);
        void B2();
    }

    public interface IC : IA, IB
    {
        void C();
    }

    class Inter : IC
    {
        public void A()
        {
            throw new System.NotImplementedException();
        }

        public int B1(int b)
        {
            throw new System.NotImplementedException();
        }

        public void B2()
        {
            throw new System.NotImplementedException();
        }

        public void C()
        {
            throw new System.NotImplementedException();
        }
    }
}