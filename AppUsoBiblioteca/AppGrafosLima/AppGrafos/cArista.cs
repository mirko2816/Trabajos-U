public class CArista
{
    private int aI;
    private int aJ;
    private float aPeso;

    public CArista()
    {
        aI = 0;
        aJ = 0;
        aPeso = 0;
    }
    public CArista(int pI, int pJ, float pPeso)
    {
        aI = pI;
        aJ = pJ;
        aPeso = pPeso;
    }

    public int I
    {
        get { return aI; }
        set { aI = value; }
    }
    public int J
    {
        get { return aJ; }
        set { aJ = value; }
    }
    public float Peso
    {
        get { return aPeso; }
        set { aPeso = value; }
    }

    public override string ToString()
    {
        return "i = " + I + ", j = " + J + ", peso = " + Peso;
    }
}