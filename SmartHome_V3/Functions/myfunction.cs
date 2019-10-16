using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class myfunction
{
    private static int action;
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static void LightCalc(float lux)
    {
        int result = -1;
        if (lux < 45)
            result = 1;
        else if (lux > 45)
            result = 0;
        action = result;
    }
    public static string LightAI(float num)
    {
        LightCalc(num);
        if (action == 1)
            return "{\"ID\":\"xuebo\",\"Device\":\"lamp 1\",\"Status\":\"1\"}";
        else if (action == 0)
            return "{\"ID\":\"xuebo\",\"Device\":\"lamp 1\",\"Status\":\"0\"}";
        else return "Hello";
    }
}
