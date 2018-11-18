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
        public override string ToString()
        {
            return "Lexeme: " + lexeme + " | " + type;
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

    protected void OnButton2Clicked(object sender, EventArgs e)
    {
        List<Token> symbolTable = new List<Token>();
        Token tok = new Token();
        symbolTable.Add(tok);

        string contents = File.ReadAllText("/home/fjmanglicmot/Projects/ArnoldCInterpreter/ArnoldCInterpreter/input.arnoldc");


        string contents_no_white_spaces = Regex.Replace(contents, " {2,}", " "); //removes multiples spaces in the string 
    
       
  
        // Define a regular expression for repeated words.

        Regex validTokens = new Regex(@"\s-?\d+|"".*""|IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU’RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL|[a-zA-Z]+[0-9]*", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                     
       

        //for determining the type of lexeme
        String keywords = @"IT'S\sSHOWTIME|YOU\sHAVE\sBEEN\sTERMINATED|HEY\sCHRISTMAS\sTREE|YOU\sSET\sUS\sUP|GET\sTO\sTHE\sCHOPPER|HERE\sIS\sMY\sINVITATION|ENOUGH\sTALK|GET\sUP|GET\sDOWN|YOU’RE\sFIRED|HE\sHAD\sTO\sSPLIT|YOU\sARE\sNOT\sYOU\sYOU\sARE\sME|LET\sOFF\sSOME\sSTEAM\sBENNET|CONSIDER\sTHAT\sA\sDIVORCE|KNOCK\sKNOCK|TALK\sTO\sTHE\sHAND|GET\sYOUR\sASS\sTO\sMARS|DO\sIT\sNOW|I\sWANT\sTO\sASK\sYOU\sA\sBUNCH\sOF\sQUESTIONS\sAND\sI\sWANT\sTO\sHAVE\sTHEM\sANSWERED\sIMMEDIATELY|BULLSHIT|BECAUSE\sI'M\sGOING\sTO\sSAY\sPLEASE|YOU\sHAVE\sNO\sRESPECT\sFOR\sLOGIC|STICK\sAROUND|CHILL";
        String integers = @"\s-?\d+";
        String non_keyword_identifier = @"[a-zA-Z]+[0-9]*";
        String strings = @""".*""";

        // Find matches.
        MatchCollection matches = validTokens.Matches(contents_no_white_spaces);

        for (int i = 0; i < matches.Count; i++)
        {
            symbolTable.Add(new Token());
        }
        for (int i = 0; i < matches.Count; i++){

            symbolTable[i].lexeme = matches[i].ToString();

            contents_no_white_spaces = Regex.Replace(contents_no_white_spaces, matches[i].ToString(), String.Empty);


            if (Regex.IsMatch(matches[i].ToString(), keywords)){

                symbolTable[i].type = "keyword";


            }else if (Regex.IsMatch(matches[i].ToString(), integers)){

                symbolTable[i].type = "integer";

            }else if (Regex.IsMatch(matches[i].ToString(), strings)){

                symbolTable[i].type = "string";

            }else if (Regex.IsMatch(matches[i].ToString(), non_keyword_identifier)){

                symbolTable[i].type = "non keyword identifier";

            }
        }
        foreach (var item in symbolTable) Console.WriteLine(item);
        contents_no_white_spaces = Regex.Replace(contents_no_white_spaces, @"\r\n", String.Empty);
      
        label1.Text = "Here are the invalid identifiers:\n" + contents_no_white_spaces + "\nCheck the terminal to see the symbol table.";
    }
}
