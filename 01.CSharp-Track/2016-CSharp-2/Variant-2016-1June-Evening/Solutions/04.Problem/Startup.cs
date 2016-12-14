using System;
using System.Text.RegularExpressions;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = string.Empty;
            for (int i = 0; i < n; i++)
            {
                input = input + " " + (Console.ReadLine());
            }
            
            var blockComments = @"/\*(.*?)\*/";
            var lineComments = @"//(.*?)\r?\n";
            var strings = @"""((\\[^\n]|[^""\n])*)""";
            var verbatimStrings = @"@(""[^""]*"")+";


            string noComments = Regex.Replace(input,
            blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
            me =>
            {
                if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                    return me.Value.StartsWith("//") ? Environment.NewLine : "";
                    return me.Value;
            },
                RegexOptions.Singleline);

            
            noComments = noComments.Replace(" ", string.Empty);
            noComments = noComments.Replace("int", "int ");
            noComments = noComments.Replace("var", "var ");
            noComments = noComments.Replace("string", "string ");
            noComments = noComments.Replace("bool", "bool ");
            noComments = noComments.Replace("char", "char ");
            noComments = noComments.Replace("decimal", "decimal ");

            //noComments = noComments.Replace(Environment.NewLine, "");

            Console.WriteLine(noComments);
        }
    }
}
