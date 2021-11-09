using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;


namespace AvTipus2
{
    class Exercise
    {
        private int time;
        public bool isGoing;

        public Exercise()
        {
            time = 0;
            isGoing = true;
        }
        public String getTimer()
        {

            int min = this.time / 60;
            int sec = this.time - min * 60;
            string s, m;
            if (min<10)
            {
                m = "0" + min;
            }
            else
            {
                m = "" + min;
            }
            if (sec<10)
            {
                s = "0" + sec;
            }
            else
            {
                s = "" + sec;
            }
            return (m + ":" + s);
        }
        public void AddSec()
        {
            while (true)
            {
                this.time++;
                Thread.Sleep(1000);
            }
        }


    }
}