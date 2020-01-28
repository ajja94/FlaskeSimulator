using System;

namespace FlaskeOppgave
{
    class Bottle
    {
        public int Capacity { get; }
        public int Content { get; private set; }

        public Bottle(int capacity)
        {
            Capacity = capacity;
        }

        public void FillToTopFromTap()
        {
            Content = Capacity;
        }

        public void Fill(int volume)
        {
            Content = Math.Min(Content + volume, Capacity);
        }

        public int Empty()
        {
            var content = Content;
            Content = 0;
            return content;
        }

        public void FillToTop(Bottle bottle)
        {
            var maxFillVolume = Capacity - Content;
            var realFillVolume = Math.Min(maxFillVolume, bottle.Content);
            Content += realFillVolume;
            bottle.Content -= realFillVolume;
        }
    }
}