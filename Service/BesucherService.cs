namespace Besucher
{

    class BesucherServiceSession
    {
        public int BesucheraufSeite { get; private set; }

        public void Hochzaehlen()
        {
            BesucheraufSeite += 1;
        } 

    } 

    class BesucherServiceGesamt
    {
        public int BesucheraufSeite { get; private set; }

        public void Hochzaehlen()
        {
            BesucheraufSeite += 1;
        } 

    } 

}






 