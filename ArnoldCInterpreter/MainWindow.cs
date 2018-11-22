using System;
using Gtk;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



public partial class MainWindow : Gtk.Window
{
    class Token
    {
        public string lexeme { get; set; }
        public string type { get; set; }
        public int value { get; set; }
        public override string ToString()
        {
            return "Lexeme: " + lexeme + " | " + type + " |" + value;

        }
    }
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }


    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    public void OnButton2Clicked(object sender, EventArgs e)
    {
        List<Token> symbolTable = new List<Token>();
        Token tok = new Token();
        symbolTable.Add(tok);

        string contents = File.ReadAllText("/home/darienravier/Documents/ArnoldCInterpreter/ArnoldCInterpreter/input.arnoldc");
        // string contents = File.ReadAllText("/home/darienravier/Documents/ArnoldCInterpreter/ArnoldCInterpreter/input.arnoldc");

        string contents_no_white_spaces = Regex.Replace(contents, " {2,}", " "); //removes multiples spaces in the string 



        // Define a regular expression for repeated words.

        Regex validTokens = new Regex(@"\s-?\d+|"".*""|IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL|[a-zA-Z]+[0-9]*", RegexOptions.Compiled | RegexOptions.IgnoreCase);



        //for determining the type of lexeme
        String keywords = @"IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL";
        String arithmetic_operators = @"GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT";
        String integers = @"\s-?\d+";
        String non_keyword_identifier = @"[a-zA-Z]+[0-9_]*";
        String strings = @""".*""";

        // Find matches.
        MatchCollection matches = validTokens.Matches(contents_no_white_spaces);

        for (int i = 0; i < matches.Count; i++)
        {
            symbolTable.Add(new Token());
        }
        for (int i = 0; i < matches.Count; i++)
        {

            symbolTable[i].lexeme = matches[i].ToString();

            contents_no_white_spaces = Regex.Replace(contents_no_white_spaces, matches[i].ToString(), String.Empty);


            if (Regex.IsMatch(matches[i].ToString(), keywords))
            {

                symbolTable[i].type = "keyword";


            }
            else if (Regex.IsMatch(matches[i].ToString(), integers))
            {

                symbolTable[i].type = "integer";

            }
            else if (Regex.IsMatch(matches[i].ToString(), strings))
            {

                symbolTable[i].type = "string";

            }
            else if (Regex.IsMatch(matches[i].ToString(), non_keyword_identifier))
            {

                symbolTable[i].type = "non-keyword identifier";

            }
        }
        symbolTable.RemoveAt(matches.Count); //removes new line at the end of the code
        foreach (var item in symbolTable) Console.WriteLine(item);
        contents_no_white_spaces = Regex.Replace(contents_no_white_spaces, @"\r\n", String.Empty);

        label1.Text = "Here are the invalid identifiers:\n" + contents_no_white_spaces + "\nCheck the terminal to see the symbol table.";

        int end_of_file = matches.Count - 1;

        bool exitLoop = false;
        if (symbolTable[0].lexeme != "IT'S SHOWTIME" || symbolTable[end_of_file].lexeme != "YOU HAVE BEEN TERMINATED")
        {
            label2.Text = "Error: No declaration of starting and/or terminating identifier.";
        }
        else
        {
           
            bool isDelimited = false;
            

            for (int i = 0; i < symbolTable.Count; i++)
            {
             
                string lexeme = symbolTable[i].lexeme;

                switch (lexeme)
                {
                   
                    case "HEY CHRISTMAS TREE":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {

                            if (symbolTable[i + 2].lexeme == "YOU SET US UP")
                            {

                                if (symbolTable[i + 3].type == "integer")
                                {//dapat isama dito ang macros

                                    i += 3;

                                }
                                else
                                {
                                    Console.WriteLine("Invalid syntax: Initialized variable requires an integer/macro value.");
                                    exitLoop = true;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid syntax: Variable initialization required."); //pwede mo rin ilagay yung keyword mismo
                                exitLoop = true;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: No variable supplied.");
                            exitLoop = true;

                        }
                        break;

                    case "GET TO THE CHOPPER":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {

                            if (symbolTable[i + 2].lexeme == "HERE IS MY INVITATION")
                            {

                                if (symbolTable[i + 3].type == "integer" || symbolTable[i + 3].type == "non-keyword identifier")
                                {

                                    if (symbolTable[i + 4].lexeme == "ENOUGH TALK")
                                    {

                                        i += 4;

                                    }
                                    else if (Regex.IsMatch(symbolTable[i + 4].lexeme, arithmetic_operators))
                                    {
                                        int j = 0;
                                        //to determine how many arithmetic operations to do
                                        while (symbolTable[i + 4 + j].lexeme != "ENOUGH TALK")
                                        {
                                            if (Regex.IsMatch(symbolTable[i + 4 + j].lexeme, arithmetic_operators) || Regex.IsMatch(symbolTable[i + 4 + j + 1].lexeme, integers))
                                            {
                                                j += 2;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid syntax: Error on arithmetic operations.");
                                                exitLoop = true;
                                                break;
                                            }

                                        }
                                        i = i + (j / 2);

                               
                                    }
                                    else
                                    {

                                        Console.WriteLine("Invalid syntax: Variable re-assignment not complete.");
                                        exitLoop = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(symbolTable[i + 3].type);
                                    Console.WriteLine("Invalid syntax: Value must be an integer.");
                                    exitLoop = true;
                                }
                            }
                            else
                            {

                                Console.WriteLine("Invalid syntax: Variable ready for re-assignment but no supplied declaration.");
                                exitLoop = true;
                            }
                        }
                        else
                        {

                            Console.WriteLine("Invalid syntax: No supplied variable.");
                            exitLoop = true;
                        }

                        break;
                    case "YOU ARE NOT YOU YOU ARE ME":
                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            exitLoop = true;


                            break;
                        }
                        break;

                    case "LET OF THE STEAM BENNET":
                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            exitLoop = true;


                            break;
                        }
                        break;

                    case "CONSIDER THAT A DIVORCE":

                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            exitLoop = true;

                            break;
                        }
                        break;

                    case "KNOCK KNOCK":

                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            exitLoop = true;

                            break;
                        }
                        break;

                    case "TALK TO THE HAND":
                        if (symbolTable[i + 1].type == "string" || symbolTable[i + 1].type == "non-keyword identifier")
                        {

                        }
                        else
                        {

                            Console.WriteLine("Invalid syntax: Expected printable variable.");
                            exitLoop = true;
                            break;
                        }
                        break;

                    case "GET YOUR ASS TO MARS":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {

                            if (symbolTable[i + 2].lexeme == "DO IT NOW")
                            {

                                if (symbolTable[i + 3].lexeme == "I WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY")
                                {
                                    i += 3;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid syntax: Input function not called.");
                                    exitLoop = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid syntax: Input function not called.");
                                exitLoop = true;
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable name.");
                            exitLoop = true;
                        }
                        break;

                    case "BECAUSE I'M GOING TO SAY PLEASE":
                        isDelimited = false;
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {

                            for (int j = i; j < symbolTable.Count; j++)
                            {

                                if (symbolTable[j].lexeme == "YOU HAVE NO RESPECT FOR LOGIC")
                                {
                                    isDelimited = true;
                                    i += 1;
                                    break;

                                }
                            }
                            if (isDelimited == false)
                            {
                                Console.WriteLine("Invalid syntax: BECAUSE I'M GOING TO SAY PLEASE statement needs a delimiter.");
                                exitLoop = true;
                                break;
                            }

                            for (int j = i; j < symbolTable.Count; j++)
                            {

                                if (symbolTable[j].lexeme == "BULLSHIT")
                                {
                                    if (symbolTable[j + 1].type == "keyword" && symbolTable[j + 1].lexeme != "YOU HAVE NO RESPECT FOR LOGIC"){
                                        i += 1;
                                        Console.WriteLine("HELLO");
                                        break;
                                    }else{
                                        Console.WriteLine("Invalid syntax: BULLSHIT statement needs an argument.");
                                        exitLoop = true;
                                        break;
                                    }
                                 

                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable.");
                            exitLoop = true;
                            break;
                        }


                        break;


                    case "STICK AROUND":
                        isDelimited = false;
                        if (symbolTable[i + 1].type == "non-keyword identifier" || symbolTable[i + 1].type == "integer")//or integer
                        {

                            for (int j = i; j < symbolTable.Count; j++)
                            {

                                if (symbolTable[j].lexeme == "CHILL")
                                {
                                    isDelimited = true;
                                    i += 1;
                                    break;

                                }
                            }
                            if (isDelimited == false)
                            {
                                Console.WriteLine("Invalid syntax: STICK AROUND statement needs a delimiter.");
                                exitLoop = true;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable.");
                            exitLoop = true;
                            break;
                        }
                        break;


                    default:
                        break;
                }
                if (exitLoop) { break; }
            }
        }
        //SEMANTIC ANALYSIS
        //parse lexemes that are integers to legitimate integer

        if (exitLoop == false){ //if it passes the syntactic analysis
            List<Token> identifiers = new List<Token>();

            for (int i = 0; i < symbolTable.Count; i++)
            {
                string lexeme = symbolTable[i].lexeme;

                switch (lexeme)
                {
                    case "HEY CHRISTMAS TREE":
                        symbolTable[i + 1].value = Int32.Parse(symbolTable[i + 3].lexeme);

                        break;

                    case "GET TO THE CHOPPER": //handles arithmetic operations
                        symbolTable[i + 1].value = Int32.Parse(symbolTable[i + 3].lexeme); //gawa ka ng para sa logical operators. magtanong kay mam


                        if (Regex.IsMatch(symbolTable[i + 4].lexeme, arithmetic_operators))
                        {
                            int j = 0;
                            //to determine how many arithmetic operations to do
                            while (symbolTable[i + 4 + j].lexeme != "ENOUGH TALK")
                            {
                                if (Regex.IsMatch(symbolTable[i + 4 + j].lexeme, arithmetic_operators))
                                {
                                    j += 2;
                                }


                            }
                            for (int k = 0; k < j; k += 2)
                            { //j number of operators
                                string arith_operators = symbolTable[i + 4 + k].lexeme; //symbolTable[i + 4 + k + 1].lexeme is the integer part

                                switch (arith_operators)
                                {
                                    case "GET UP":
                                        symbolTable[i + 1].value += Int32.Parse(symbolTable[i + 4 + k + 1].lexeme);
                                        break;
                                    case "GET DOWN":
                                        symbolTable[i + 1].value -= Int32.Parse(symbolTable[i + 4 + k + 1].lexeme);
                                        break;
                                    case "YOU'RE FIRED":
                                        symbolTable[i + 1].value *= Int32.Parse(symbolTable[i + 4 + k + 1].lexeme);
                                        break;
                                    case "HE HAD TO SPLIT":
                                        symbolTable[i + 1].value /= Int32.Parse(symbolTable[i + 4 + k + 1].lexeme);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            i = i + (j / 2);


                        }
                        break;
                    
                    default:
                        break;
                }

            }
            Console.WriteLine("IDENTIFIERS WITH VALUES");
            foreach (var item in symbolTable)
            {
                if (item.value != 0)
                {
                    identifiers.Add(item);

                }
            }
            foreach (var item in identifiers) Console.WriteLine(item);
        }

          

    }





}
