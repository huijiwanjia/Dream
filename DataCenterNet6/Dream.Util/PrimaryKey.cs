using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Util
{
    public class PrimaryKey
    {
        private static object syncRoot = new object();
        private static PrimaryKey instance;
        /// <summary>
        /// 唯一ID生成类
        /// </summary>
        public static PrimaryKey Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new PrimaryKey();
                        }
                    }
                }
                return instance;
            }
        }
        private DateTime StartTime = new DateTime(2000, 1, 1);
        private int subValue = 1;
        private long lastTimeMark = 1;
        public long ID
        {
            get
            {
                long timeMark = (long)(DateTime.Now - StartTime).TotalMilliseconds;
                //return timeMark;
                //long timeMark = (long)((DateTime.Now - StartTime).TotalMilliseconds) << 8;
                if (lastTimeMark == timeMark)
                {
                    subValue++;
                }
                else
                {
                    subValue = 1;
                    lastTimeMark = timeMark;
                }
                long guid = timeMark + subValue;
                System.Threading.Thread.Sleep(1);
                return guid;
            }
        }
    }
}
