// Required flags for if and else statements



if(symbolTable[0].lexeme != "IT'S SHOWTIME" || symbolTable[end_of_file].lexeme != "YOU HAVE BEEN TERMINATED"){
	label2.Text = "Error: No declaration of starting and/or terminating identifier.";

}else{
	foreach(Token token in symbolTable){
		string lexeme = token.lexeme;
		int counter = 1;
		switch(lexeme){
			case "YOU ARE NOT YOU YOU ARE ME":
				if (symbolTable[counter + 1].type != "integer"){
					Console.WriteLine("Invalid syntax: Expected integer")
					break;
				}
			break;

			case "LET OF THE STEAM BENNET":
				if (symbolTable[counter + 1].type != "integer"){
					Console.WriteLine("Invalid syntax: Expected integer")
					break;
				}
			break;

			case "CONSIDER THAT A DIVORCE"
				if (symbolTable[counter + 1].type != "integer"){
					Console.WriteLine("Invalid syntax: Expected integer")
					break;
				}
			break;

			case "KNOCK KNOCK"
				if (symbolTable[counter + 1].type != "integer"){
					Console.WriteLine("Invalid syntax: Expected integer")
					break;
				}
			break;

			case "TALK TO THE HAND":
				if (symbolTable[counter + 1].type == "keyword identifier"){
					Console.WriteLine("Invalid syntax: Expected printable variable.");
					break;
				}

			case "GET YOUR ASS TO MARS":
				if (symbolTable[counter + 1].type != "non-keyword identifier" || symbolTable[counter + 1].lexeme != "integer"){
					Console.WriteLine("Invalid syntax: Integer");
					break;
				}
			break;

			case "DO IT NOW":
				if (symbolTable[counter + 1]. != "operator"){
					Console.WriteLine("Invalid syntax: Requires operator");
					break;
				}
				if (symbolTable[counter + 1]. != "integer" && symbolTable[counter + 2]. != "integer"){
					Console.WriteLine("Invalid syntax: Requires 2 integers");
					break;
				}
			break;

			case "I WANT TO ASK YOU A BUNCH OF QUESTIONS AND I WANT TO HAVE THEM ANSWERED IMMEDIATELY":
				break;

			case "BULLSHIT":
				if (ifel_flag == 0){
					Console.WriteLine("Invalid syntax: dangling else statement");
					break;
				}else{
					ifel_flag -= 1;
					break;
				}
			break;

			case "BECAUSE I'M GOING TO SAY PLEASE":
				if (symbolTable[counter + 1]. == "integer" || symbolTable[counter + 1]. == "strings"){
					Console.WriteLine("Invalid syntax");
					break;
				}else{
					ifel_flag += 1;
					break;
				}
			break;

			case "YOU HAVE NO RESPECT FOR LOGIC":
			
			break;

			case "STICK AROUND":
				if (symbolTable[counter + 1]. == "integer" || symbolTable[counter + 1]. == "strings"){
					Console.WriteLine("Invalid syntax");
					break;
				}else{
					while_flag += 1;
					break;
				}
			break;

			case "BULLSHIT":
				if (while_flag == 0){
					Console.WriteLine("Invalid syntax: dangling while statement");
					break;
				}else{
					while_flag -= 1;
					break;
				}
			break;



		}
	}
}