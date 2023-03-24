
using (StreamReader rd = new StreamReader("input.txt"))
{
    string klammerline = null;

    while ((klammerline = rd.ReadLine()) != null)
    {


        Console.WriteLine(klammerline);

    }


}




