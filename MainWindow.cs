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

    protected void OnFileChooserBtnClicked(object sender, EventArgs e){
        //Clears the codeview
        codeView.Buffer.Text = "";

        //Input test case
        string text = inputEntry.Text;
        codeView.Buffer.Insert(codeView.Buffer.EndIter, text);
    }

    protected void OnExecuteBtnClicked(object sender, EventArgs e)
    {
        List<Token> symbolTable = new List<Token>();
        Token tok = new Token();
        symbolTable.Add(tok);

        //Clears the consoleview
        //For any repeat of the execute button
        consoleView.Buffer.Text = "";

        consoleView.Buffer.Text = "Here are the invalid identifiers:\n";

        //Lexeme Table -> TreeView
        Gtk.ListStore lexemeListStore = new Gtk.ListStore(typeof(string), typeof(string));
        lexemeView.Model = lexemeListStore;
        //Lexeme Column
        var lexemeColumn = new TreeViewColumn
        {
            Title = "Lexeme",
            Clickable = false
        };
        var lexemeRenderer = new CellRendererText();
        lexemeColumn.PackStart(lexemeRenderer, true);
        lexemeColumn.AddAttribute(lexemeRenderer, "text", 0);
        lexemeView.AppendColumn(lexemeColumn);
        //Type Column
        var typeColumn = new TreeViewColumn
        {
            Title = "Type",
            Clickable = false
        };
        var typeRenderer = new CellRendererText();
        typeColumn.PackStart(typeRenderer, true);
        typeColumn.AddAttribute(typeRenderer, "text", 1);
        lexemeView.AppendColumn(typeColumn);

        //Symbol Table -> TreeView
        Gtk.ListStore symbolTableListStore = new Gtk.ListStore(typeof(string), typeof(int));
        symbolTableView.Model = symbolTableListStore;
        //Identifier Column
        var identifierColumn = new TreeViewColumn
        {
            Title = "Identifier",
            Clickable = false
        };
        var identificationRenderer = new CellRendererText();
        identifierColumn.PackStart(identificationRenderer, true);
        identifierColumn.AddAttribute(identificationRenderer, "text", 0);
        symbolTableView.AppendColumn(identifierColumn);
        //Value Column
        var valueColumn = new TreeViewColumn
        {
            Title = "Value",
            Clickable = false
        };
        var valueRenderer = new CellRendererText();
        valueColumn.PackStart(valueRenderer, true);
        valueColumn.AddAttribute(valueRenderer, "text", 1);
        symbolTableView.AppendColumn(valueColumn);

        var consoleScreen = consoleView.Buffer;
        var codeScreen = codeView.Buffer;



        string contents = File.ReadAllText("/home/darienravier/Documents/CMSC124-ArnoldC/input.arnoldc");
        //string contents = File.ReadAllText("/home/darienravier/Documents/ArnoldCInterpreter/input.arnoldc");

        //Displays contents in the codeView
        codeScreen.Insert(codeScreen.EndIter, contents);
        //codeScreen.Insert(codeScreen.EndIter, "\nSHIT\n");

        string contents_no_white_spaces = Regex.Replace(contents, " {2,}", " "); //removes multiples spaces in the string 



        // Define a regular expression for repeated words.
        //Old Regex
        //Regex validTokens = new Regex(@"\s-?\d+|"".*""|IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL|[a-zA-Z]+[0-9]*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        //New Regex
        Regex validTokens = new Regex(@"\s-?\d+|"".*""|IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL|@I\sLIED|@NO\sPROBLEMO|[a-zA-Z]+[0-9]*", RegexOptions.Compiled | RegexOptions.IgnoreCase);


        //for determining the type of lexeme
        String keywords = @"IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL";
        String arithmetic_operators = @"GET\sUP|GET\sDOWN|YOU'RE\sFIRED|HE\sHAD\sTO\sSPLIT";
        String logical_operators = @"YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK";
        String integers = @"\s-?\d+";
        String non_keyword_identifier = @"[a-zA-Z]+[0-9_]*";
        String strings = @""".*""";
       //String macros = @"@I\sLIED|@NO\sPROBLEMO";

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
            else if (Regex.IsMatch(matches[i].ToString(), @"@I\sLIED"))
            {

                symbolTable[i].type = "integer";
                symbolTable[i].lexeme = "0";


            }
            else if (Regex.IsMatch(matches[i].ToString(), @"@NO\sPROBLEMO"))
            {

                symbolTable[i].type = "integer";
                symbolTable[i].lexeme = "1";

            }
            else if (Regex.IsMatch(matches[i].ToString(), non_keyword_identifier))
            {

                symbolTable[i].type = "non-keyword identifier";

            }
        }
        symbolTable.RemoveAt(matches.Count); //removes new line at the end of the code
        foreach (var item in symbolTable) Console.WriteLine(item);
        contents_no_white_spaces = Regex.Replace(contents_no_white_spaces, @"\r\n", String.Empty);



        int end_of_file = matches.Count - 1;

        bool exitLoop = false;
        if (symbolTable[0].lexeme != "IT'S SHOWTIME" || symbolTable[end_of_file].lexeme != "YOU HAVE BEEN TERMINATED")
        {
            consoleScreen.Insert(consoleScreen.EndIter, "\nError: No declaration of starting and/or terminating identifier.");
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
                                    consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Initialized variable requires an integer/macro value.");
                                    exitLoop = true;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid syntax: Variable initialization required."); //pwede mo rin ilagay yung keyword mismo
                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Variable initialization required.");
                                exitLoop = true;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: No variable supplied.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: No variable supplied.");
                            exitLoop = true;

                        }
                        break;

                    case "GET TO THE CHOPPER": //PRE NAKALIMUTAN MO YUNG LOGICAL OPERATORS AT KUNG VARIABLE ANG LAMAN NIYA
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
                                    else if (Regex.IsMatch(symbolTable[i + 4].lexeme, arithmetic_operators) || Regex.IsMatch(symbolTable[i + 4].lexeme, logical_operators))
                                    {
                                        int j = 0;
                                        //to determine how many arithmetic operations to do
                                        while (symbolTable[i + 4 + j].lexeme != "ENOUGH TALK")
                                        {
                                            if ((Regex.IsMatch(symbolTable[i + 4 + j].lexeme, arithmetic_operators) || Regex.IsMatch(symbolTable[i + 4 + j].lexeme, logical_operators) && (Regex.IsMatch(symbolTable[i + 4 + j + 1].lexeme, integers) || symbolTable[i + 4 + j + 1].type == "non-keyword identifier")))
                                            {
                                                j += 2;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid syntax: Error on arithmetic operations.");
                                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Error on arithmetic operations.");
                                                exitLoop = true;
                                                break;
                                            }

                                        }
                                        i = i + (j / 2);


                                    }
                                    else
                                    {

                                        Console.WriteLine("Invalid syntax: Variable re-assignment not complete.");
                                        consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Variable re-assignment not complete.");
                                        exitLoop = true;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(symbolTable[i + 3].type);
                                    Console.WriteLine("Invalid syntax: Value must be an integer.");
                                    string printable = "\n" + symbolTable[i + 3].type + "Invalid syntax: Value must be an integer.";
                                    consoleScreen.Insert(consoleScreen.EndIter, printable);
                                    exitLoop = true;
                                }
                            }
                            else
                            {

                                Console.WriteLine("Invalid syntax: Variable ready for re-assignment but no supplied declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Variable ready for re-assignment but no supplied declaration.");
                                exitLoop = true;
                            }
                        }
                        else
                        {

                            Console.WriteLine("Invalid syntax: No supplied variable.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: No supplied variable.");
                            exitLoop = true;
                        }

                        break;
                    case "YOU ARE NOT YOU YOU ARE ME":
                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected integer");
                            exitLoop = true;


                            break;
                        }
                        break;

                    case "LET OF THE STEAM BENNET":
                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            consoleScreen.Insert(consoleScreen.EndIter, "Invalid syntax: Expected integer");
                            exitLoop = true;


                            break;
                        }
                        break;

                    case "CONSIDER THAT A DIVORCE":

                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected integer");
                            exitLoop = true;

                            break;
                        }
                        break;

                    case "KNOCK KNOCK":

                        if (symbolTable[i + 1].type != "integer")
                        {
                            Console.WriteLine("Invalid syntax: Expected integer");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected integer");
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
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected printable variable.");
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
                                    consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Input function not called.");
                                    exitLoop = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid syntax: Input function not called.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Input function not called.");
                                exitLoop = true;
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable name.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected variable name.");
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
                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: BECAUSE I'M GOING TO SAY PLEASE statement needs a delimiter.");
                                exitLoop = true;
                                break;
                            }

                            for (int j = i; j < symbolTable.Count; j++)
                            {

                                if (symbolTable[j].lexeme == "BULLSHIT")
                                {
                                    if (symbolTable[j + 1].type == "keyword" && symbolTable[j + 1].lexeme != "YOU HAVE NO RESPECT FOR LOGIC")
                                    {
                                        i += 1;
                                        Console.WriteLine("HELLO");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid syntax: BULLSHIT statement needs an argument.");
                                        consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: BULLSHIT statement needs an argument.");
                                        exitLoop = true;
                                        break;
                                    }


                                }
                            }


                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected variable.");
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
                                consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: STICK AROUND statement needs a delimiter.");
                                exitLoop = true;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid syntax: Expected variable.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nInvalid syntax: Expected variable.");
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

        int iterations = 0;
        int loop_length = 0;

        bool exitLoopSemantic = false;
        if (exitLoop == false)
        { //if it passes the syntactic analysis
            List<Token> identifiers = new List<Token>();

            for (int i = 0; i < symbolTable.Count; i++)
            {
                string lexeme = symbolTable[i].lexeme;

                switch (lexeme)
                {
                       case "HEY CHRISTMAS TREE": //di sure kung sa semantic pa to
                            foreach (var item in symbolTable)
                            {
                                if (item.lexeme == symbolTable[i + 1].lexeme)
                                {
                                   symbolTable[i + 1].value = Int32.Parse(symbolTable[i + 3].lexeme);
                                   //Console.WriteLine(item.value);
                                   identifiers.Add(symbolTable[i + 1]);

                                }
                            }


                        break;

                    case "GET TO THE CHOPPER": //handles arithmetic operations
                        bool isDeclared = false;

                                                for (int j = 0; j < i; j++)
                                                    {

                                                        if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                                            {
                                isDeclared = true;
                                                                //USE THES CODE BLOCKS FOR EXECUTION
                                                               //symbolTable[i + 1].value = Int32.Parse(symbolTable[i + 3].lexeme); //HERE IS MY INVITATION
                                                                 foreach (var item in symbolTable)
                                {
                                                                         if (item.lexeme == symbolTable[i + 1].lexeme)
                                    {

                                        item.value = Int32.Parse(symbolTable[i + 3].lexeme);
                                        identifiers.Add(symbolTable[i + 1]);
                                                                             }

                                                                     }


                                                                if (Regex.IsMatch(symbolTable[i + 4].lexeme, arithmetic_operators) || Regex.IsMatch(symbolTable[i + 4].lexeme, logical_operators))
                                                                    {
                                    int l = 0;
                                                                        //to determine how many arithmetic operations to do
                                                                        while (symbolTable[i + 4 + l].lexeme != "ENOUGH TALK")
                                                                           {
                                                                                if (Regex.IsMatch(symbolTable[i + 4 + l].lexeme, arithmetic_operators) || Regex.IsMatch(symbolTable[i + 4].lexeme, logical_operators))
                                                                                    {
                                            l += 2;
                                                                                   }


                                                                            }
                                                                        for (int k = 0; k < l; k += 2)
                                                                            { //j number of operators
                                        string arith_operators = symbolTable[i + 4 + k].lexeme; //symbolTable[i + 4 + k + 1].lexeme is the integer part
                                        int arithmeticParameter = i + 4 + k + 1;

                                                                                switch (arith_operators)
                                        {
                                                                                        case "GET UP":
                        
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                            symbolTable[i + 1].value += Int32.Parse(symbolTable[arithmeticParameter].lexeme);
                            identifiers.Add(symbolTable[i + 1]);
                                                                            }
                                                                       else if (symbolTable[arithmeticParameter].type == "non-keyword identifier")
                                                                           {
                            
                            
                            
                                                                               foreach (var item in symbolTable)
                                                                                    {
                                                                                       if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                            {
                                    
                                    symbolTable[i + 1].value += item.value;
                                    identifiers.Add(symbolTable[i + 1]);
                                    
                                                                                          }
                                                                                    }
                            
                                                                            }
                        
                        
                                                                        break;
                                                                    case "GET DOWN":
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                            symbolTable[i + 1].value -= Int32.Parse(symbolTable[arithmeticParameter].lexeme);
                            identifiers.Add(symbolTable[i + 1]);
                                                                            }
                                                                        else if (symbolTable[i + 4 + k + 1].type == "non-keyword identifier")
                                                                            {
                            
                                                                                //symbolTable[i + 1].value -= symbolTable[arithmeticParameter].value;
                                                                                foreach (var item in symbolTable)
                                                                                    {
                                                                                        if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                            {
                                                                                                //Console.WriteLine(item);
                                    symbolTable[i + 1].value -= item.value;
                                    identifiers.Add(symbolTable[i + 1]);
                                                                                            }
                                                                                    }
                                                                           }
                        
                        
                                                                        break;
                                                                    case "YOU'RE FIRED":
                                                                       if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                            symbolTable[i + 1].value *= Int32.Parse(symbolTable[arithmeticParameter].lexeme);
                            identifiers.Add(symbolTable[i + 1]);
                                                                            }
                                                                        else if (symbolTable[i + 4 + k + 1].type == "non-keyword identifier")
                                                                            {
                            
                                                                               //symbolTable[i + 1].value += symbolTable[arithmeticParameter].value;
                                                                                foreach (var item in symbolTable)
                                                                                    {
                                                                                        if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                            {
                                                                                                //Console.WriteLine(item);
                                    symbolTable[i + 1].value = symbolTable[i + 1].value * item.value;
                                    identifiers.Add(symbolTable[i + 1]);
                                                                                            }
                                                                                    }
                                                                            }
                        
                        
                                                                       break; ;
                                                                    case "HE HAD TO SPLIT":
                                                                        if (symbolTable[arithmeticParameter].type == "integer") //CATCH MO YUNG DIVISION BY ZERO
                                                                            {
                            symbolTable[i + 1].value = symbolTable[i + 1].value / Int32.Parse(symbolTable[arithmeticParameter].lexeme);
                            identifiers.Add(symbolTable[i + 1]);
                                                                            }
                                                                        else if (symbolTable[i + 4 + k + 1].type == "non-keyword identifier")
                                                                            {
                            
                            symbolTable[i + 1].value /= symbolTable[arithmeticParameter].value;
                                                                                foreach (var item in symbolTable)
                                                                                    {
                                                                                        if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                            {
                                                                                                //Console.WriteLine(item);
                                    symbolTable[i + 1].value = symbolTable[i + 1].value / item.value;
                                    identifiers.Add(symbolTable[i + 1]);
                                                                                            }
                                                                                    }
                                                                            }
                        
                        
                                                                        break;
                                                                    case "YOU ARE NOT YOU YOU ARE ME":
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                                                                                if (Int32.Parse(symbolTable[arithmeticParameter].lexeme) == symbolTable[i + 1].value)
                                                                                    {
                                symbolTable[i + 1].value = 1;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                                else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                
                                                                                    }
                                                                            }
                                                                        else if (symbolTable[arithmeticParameter].type == "non-keyword identifier")
                                                                            {
                            
                                                                                if (symbolTable[arithmeticParameter].value == symbolTable[i + 1].value)
                                                                                   {
                               Console.WriteLine("dito");
                               Console.WriteLine("{0} and {1}", symbolTable[arithmeticParameter].value, symbolTable[i + 1].value);
                               
                                
                                                                                        foreach (var item in symbolTable)
                                                                                            {
                                                                                                if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                                    {
                                        Console.WriteLine(item);
                                        Console.WriteLine("dito");
                                        symbolTable[i + 1].value = 1;
                                        identifiers.Add(symbolTable[i + 1]);
                                                                                                    }
                                                                                            }
                                
                                                                                        break;
                                                                                    }
                                                                                else if (symbolTable[arithmeticParameter].value != symbolTable[i + 1].value)
                                                                                    {
                                Console.WriteLine("doon");
                                
                                                                                        foreach (var item in symbolTable)
                                                                                            {
                                                                                                if (item.lexeme == symbolTable[arithmeticParameter].lexeme)
                                                                                                    {
                                        Console.WriteLine(item);
                                        symbolTable[i + 1].value = 0;
                                        identifiers.Add(symbolTable[i + 1]);
                                                                                                    }
                                                                                            }
                                
                                                                                        break;
                                
                                                                                    }
                                                                            }
                        
                        
                                                                        break;
                                                                    case "LET OFF SOME STEAM BENNET":
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                            
                                                                                if (symbolTable[i + 1].value > Int32.Parse(symbolTable[arithmeticParameter].lexeme))
                                                                                    {
                                
                                symbolTable[i + 1].value = 1;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                              else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                
                                
                                                                                    }
                                                                            }
                                                                        else if (symbolTable[arithmeticParameter].type == "non-keyword identifier")
                                                                            {
                            
                                                                                if (symbolTable[i + 1].value > symbolTable[arithmeticParameter].value)
                                                                                {
                            
                                symbolTable[i + 1].value = 1;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                
                                                                                    }
                                                                                else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                           }
                                                                                                                       break;
                                                                    case "CONSIDER THAT A DIVORCE":
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                           {
                            
                                                                                if ((symbolTable[i + 1].value == 0 && Int32.Parse(symbolTable[arithmeticParameter].lexeme) == 1) || (symbolTable[i + 1].value == 1 && Int32.Parse(symbolTable[arithmeticParameter].lexeme) == 0))
                                                                                    {
                                
                                symbolTable[i + 1].value = 1;
                                identifiers.Add(symbolTable[i + 1]);
                                                                                    }
                                                                                else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                            }
                                                                        else if (symbolTable[arithmeticParameter].type == "non-keyword identifier") //fix this, di niya nakikita yung totoong value ng arithparameter
                                                                            {
                            
                                                                                if ((symbolTable[i + 1].value == 0 && symbolTable[arithmeticParameter].value == 1) || (symbolTable[i + 1].value == 1 && symbolTable[arithmeticParameter].value == 0))
                                                                                    {
                                
                                symbolTable[i + 1].value = 1;
                                
                                identifiers.Add(symbolTable[i + 1]);
                                                                                    }
                                                                                else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                            }
                        
                        
                                                                        break;
                                                                    case "KNOCK KNOCK":
                                                                        if (symbolTable[arithmeticParameter].type == "integer")
                                                                            {
                            
                                                                                if (symbolTable[i + 1].value == 1 && Int32.Parse(symbolTable[arithmeticParameter].lexeme) == 1)
                                                                                    {
                                
                                symbolTable[i + 1].value = 1;
                                identifiers.Add(symbolTable[i + 1]);
                                                                                    }
                                                                               else
                                                   {
                                
                                symbolTable[i + 1].value = 0;
                                
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                            }
                                                                        else if (symbolTable[arithmeticParameter].type == "non-keyword identifier")
                                                                            {
                            
                                                                                if (symbolTable[i + 1].value == 1 && symbolTable[arithmeticParameter].value == 1)
                                                                                    {
                                
                                symbolTable[i + 1].value = 1;
                                
                                identifiers.Add(symbolTable[i + 1]);
                                                                                    }
                                                                                else
                                                    {
                                
                                symbolTable[i + 1].value = 0;
                                identifiers.Add(symbolTable[i + 1]);
                                
                                                                                    }
                                                                            }
                        
                        
                                                                        break;
                        
                        
                        
                                                                }
                
                                                    }
            
            i = i + (l / 2);
            
                                            }
                                        else exitLoop = true; break;
                                }
                       
                       


                        }
                        if (isDeclared == false)
                        {
                            Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                            exitLoopSemantic = true;
                            break;
                        }
                        break;
                    case "GET UP":
                        if (symbolTable[i + 1].type == "non-keyword identifier"){
                            bool isDeclaredGetUp = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredGetUp = true;
                                  
                                    break;

                                }
                            }
                            if (isDeclaredGetUp == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "GET DOWN":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredGetDown = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredGetDown = true;

                                    break;

                                }
                            }
                            if (isDeclaredGetDown == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "YOU'RE FIRED":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredFired = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredFired = true;

                                    break;

                                }
                            }
                            if (isDeclaredFired == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "HE HAD TO SPLIT":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredSplit = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredSplit = true;

                                    break;

                                }
                            }
                            if (isDeclaredSplit == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "LET OF SOME STEAM BENNET":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredSteam = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredSteam = true;

                                    break;

                                }
                            }
                            if (isDeclaredSteam == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                   
                    case "YOU ARE NOT YOU YOU ARE ME":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredYou = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredYou = true;

                                    break;

                                }
                            }
                            if (isDeclaredYou == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "CONSIDER THAT A DIVORCE":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredDivorce = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredDivorce = true;

                                    break;

                                }
                            }
                            if (isDeclaredDivorce == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                        }
                        break;
                    case "KNOCK KNOCK":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                        {
                            bool isDeclaredKnock = false;
                            for (int j = 0; j<i; j++)
                            {


                                if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                {
                                    isDeclaredKnock = true;

                                    break;

                                }
                            }
                            if (isDeclaredKnock == false)
                            {
                                Console.WriteLine("Semantic error: Variable reassigned before declaration.");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nSemantic error: Variable reassigned before declaration.");
                                exitLoopSemantic = true;
                                break;
                            }
                         }
                        break;
                    case "TALK TO THE HAND":
                        if (symbolTable[i + 1].type == "non-keyword identifier")
                            {
                                bool isDeclaredKnock = false;
                                for (int j = 0; j < i; j++)
                                {
                                    if (symbolTable[j].lexeme == symbolTable[i + 1].lexeme)
                                        {
                                            isDeclaredKnock = true;
                                            for (int o = identifiers.Count - 1; o != 0; o--)
                                                {
                                                    if (identifiers[o].lexeme == symbolTable[i + 1].lexeme)
                                                        {
                                                            Console.WriteLine(identifiers[o].value);
                                                            //Textview cannot print integers everything must be converted to string
                                                            string printValue = "\n" + identifiers[o].value.ToString();
                                                            consoleScreen.Insert(consoleScreen.EndIter, printValue);
                                                            break;
                                                        }
                                                  }
                                                  break;
                                          }
                                  }
                                     if (isDeclaredKnock == false)
                                        {
                                            Console.WriteLine("Semantic error: Variable reassigned before delcaration.");
                                            exitLoopSemantic = true;
                                            break;
                                         }
                                      }else if (symbolTable[i + 1].type == "string")
                                        {
                                            Console.WriteLine(symbolTable[i + 1].lexeme);
                                            string printString = "\n" + symbolTable[i + 1].lexeme;
                                            consoleScreen.Insert(consoleScreen.EndIter, printString);
                                        }
                                   break;
                    case "GET YOUR ASS TO MARS":

                        //pwedeng ang gawin dito ay magprint sa textbox ng console ng "Enter value: " tas from the textbox, kunin nalang yung value
                        //or pwede namang may hiwalay na textbox for user input tas hiwalay yung console for printing yung mga ginagawa ng code
                        string input = Console.ReadLine(); //pero for now ito muna
                        //kapag may sariling textbox, pwedeng  symbolTable[i + 1].value = textLabel.text parang ganyan ->pero siyempre iparse mo to int
                        symbolTable[i + 1].value = Int32.Parse(input);
                        //Console.WriteLine(symbolTable[i + 1].value);
                        break;
                    /*case "BECAUSE I'M GOING TO SAY PLEASE":
                    if (symbolTable[i + 1].value == 1)
                    {
                        break;
                    }
                    else
                    {

                    }
                    break;*/

                    case "STICK AROUND":
                        string next_lex = symbolTable[i + 1].lexeme;

                        for (int j = 0; i < symbolTable.Count; i++)
                        {
                            if (symbolTable[j].lexeme == next_lex)
                            {
                                break;
                            }

                            if (i < j)
                            {
                                Console.WriteLine("Error no initialized variable");
                                consoleScreen.Insert(consoleScreen.EndIter, "\nError no initialized variable");
                                break;
                            }
                        }

                        if (symbolTable[i + 1].type == "non-keyword identifer" || symbolTable[i + 1].type == "integer")
                        {
                            iterations = symbolTable[i + 1].value;
                        }
                        else
                        {
                            Console.WriteLine("Error: expected integer");
                            consoleScreen.Insert(consoleScreen.EndIter, "\nError: expected integer");
                        }

                        loop_length = 0;
                        for (int k = i + 2; k < symbolTable.Count; k++)
                        {
                            if (symbolTable[k].lexeme != "CHILL")
                            {
                                loop_length += 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                        i++;
                        break;

                    case "CHILL":
                        Console.WriteLine("iterations left: {0}", iterations);
                        consoleScreen.Insert(consoleScreen.EndIter, "\nIterations Left: " + iterations);
                        Console.WriteLine("Loop Length: {0}", loop_length);
                        consoleScreen.Insert(consoleScreen.EndIter, "\nLoop Length: " + loop_length);
                        if (iterations != 0)
                        {
                            i -= loop_length;
                        }
                        break;

                    default:
                        break;
                }
                if (exitLoopSemantic) { break; }
            }
            Console.WriteLine("IDENTIFIERS WITH VALUES");

            foreach (var item in identifiers) Console.WriteLine(item);

            //symbolTableView.Model.Clear();
            //Prints values in the Symbol Table
            //This just gets all the non-keyword identifier
            for (int i = 0; i < identifiers.Count; i++)
            {
                symbolTableListStore.AppendValues(identifiers[i].lexeme, identifiers[i].value);
            }

            //lexemeView.Model.Clear();
            //Prints the values in the Lexeme Table
            for (int i = 0; i < matches.Count; i++)
            {
                lexemeListStore.AppendValues(symbolTable[i].lexeme, symbolTable[i].type);
            }
        }




    }

}

