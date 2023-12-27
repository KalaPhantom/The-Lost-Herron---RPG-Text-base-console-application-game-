using player;

namespace Highscore{


// This is not my original code
// it is coined from:

//

    class Score{

        public static void Score_writer(int SC, int HS){


            string high_score = @"High_Score_System\Current_highscore.txt";
            string current_score = @"High_Score_System\Current_score.txt";

           StoreScoreValue(high_score,SC);
           StoreScoreValue(current_score,HS);


        }
        public static void StoreScoreValue(string fileName, int value){
            using (StreamWriter writer = new StreamWriter(fileName)){
            writer.WriteLine(value); 
             }
         }

       
          public static int High_Score(){ // High Score
            int result = 0;
            string fileName = @"High_Score_System\Current_highscore.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName)){ // -- > read the existing filename
                    string line = reader.ReadLine(); // Read the context of the text file
                    if (int.TryParse(line, out result)){
                        return result;
                    }
                }
             }

            return result;
         }
          public static int Score_current(){ // recent score
            int result = 0;
            string fileName = @"High_Score_System\Current_score.txt" ;

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName)){ // -- > read the existing filename
                    string line = reader.ReadLine(); // Read the context of the text file
                    if (int.TryParse(line, out result)){
                        return result;
                    }
                }
             }

            return result;
         }


        public static void Delete_or_update_score(string fileName){ // Only going to be called when a new data / scores has to be updated
             // Simply overwrite the file with an empty string to clear its content
            File.WriteAllText(fileName, string.Empty); // --> Delete the contents of the file
        }

    }
}