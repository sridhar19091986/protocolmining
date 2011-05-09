namespace AutoUpdater
{
    using System;

    public class ProcShow
    {
        public string labelShow;
        public string logShow;
        public int mainV;
        public int subV;

        public ProcShow()
        {
        }

        public ProcShow(int mainv, int subv, string labelshow, string logshow)
        {
            this.mainV = mainv;
            this.subV = subv;
            this.labelShow = labelshow;
            this.logShow = logshow;
        }
    }
}

