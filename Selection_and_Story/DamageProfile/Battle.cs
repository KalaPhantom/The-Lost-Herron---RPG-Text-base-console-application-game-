
using player;
using enemy;
using Battle_Mechanics;
using Selection;


namespace Simulations{ 
    class Batte_Simulation{

        public static bool is_pl_defeated = false;
        public static void action_box_pos(){
            Console.SetCursorPosition(36,4);
        }
        public static void action_box_pos_s2(){
            Console.SetCursorPosition(36,5);

             
        }
        public static void action_box_resetter(){
            Console.SetCursorPosition(36,4);
            Console.Write("                                       ");
            Console.SetCursorPosition(36,5);
            Console.WriteLine("                                    ");                                                   
        }
      
         public static void battle1(int a, int b,int c, int d, int e, string cc){ // Enemy-- Where a = for the enemy health ||| b is for the enemy damage ||| c is for the enemy dodge rate ||| d is for the enemy attack rate || e is for the enemy miss rate
         
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor= ConsoleColor.DarkCyan;
           layout.Box_Generator(34,2,4,80);
           Console.ResetColor();

            while ( Player.Pl_alive== true && Enemy.En_alive == true){
                Random dmg_e = new Random();
                int en_actions = dmg_e.Next(1,100); // Random Percentage
                int pl_actions = dmg_e.Next(1,100); // Random Percentage 
                int en_attack = dmg_e.Next(1,3); // Random attack attributer 
                int pl_attack = dmg_e.Next(1,3); // Random attack attributer
                int en_miss_chances = dmg_e.Next(1,100);
                int player_flee = dmg_e.Next(1,100);
                 bool is_player_fled = false;

                

                // HP Visualization
                healthBar.Battle(a,b,pl_actions,d,c,cc);
              
               
                Thread.Sleep(5);

            
                // Battle event
                bool enemy_dodge = false;
                 // needed to be assigned so the enemy can also miss an attack bay 30 percent or depends on the enemy algorithm
               

                system_selection.sel_2_battle("Attack","Dodge","Flee"); // Called for the selection
                switch(system_selection.battle_sel_option){

                    case 1: // Player attack choice

                   
                        action_box_resetter(); action_box_pos(); anima.anima1("You choose to attack");
                        switch(en_actions <c? "attack" : en_actions >d? "dodge": "attack" ){ // Random enemy response
                            case "attack":  
                            if (enemy_dodge == false){a -= Player.damage*pl_attack; action_box_resetter(); action_box_pos(); Console.Write("You hit the enemy !!!"); healthBar.Battle(a,b,pl_actions,d,c,cc); }// Player attack
                            if(en_miss_chances>e){ Player.battle_health -= b  *en_attack; action_box_resetter(); action_box_pos(); anima.anima1("The enemy manages to retaliate"); healthBar.Battle(a,b,pl_actions,d,c,cc);  }//Enemy retalliate
                            else if(en_miss_chances < e){action_box_resetter(); action_box_pos(); anima.anima1("The enemy attack but misses"); Thread.Sleep(1000);}
                           
                            break; // enemy attack
                            case "dodge": enemy_dodge = true; action_box_resetter(); action_box_pos(); Thread.Sleep(1000); anima.anima1("Enemy dodged your attack and retaliates"); Player.battle_health -= b  *en_attack;  healthBar.Battle(a,b,pl_actions,d,c,cc); break;
                    
                         }
                          if (enemy_dodge == true) { enemy_dodge = false; }
                          
                    break;

                    case 2: // Player dodge choice 
                        switch (pl_actions <60? "Dodge" : pl_actions > 60?"Fail": "Dodge"){
                            case "Dodge": action_box_resetter(); action_box_pos(); Console.WriteLine("you dodged the enemy");break;
                            case "Fail": action_box_resetter(); action_box_pos();anima.anima1("You failed to dodge");  Player.battle_health -= b  *en_attack; break; 
                        }
                     break;
                    case 3: action_box_resetter(); action_box_pos(); anima.anima1("You tried to flee . . . . . . "); Thread.Sleep(500);

                    switch (player_flee < 10? "flee" : "fail"){
                        case "flee": action_box_resetter(); action_box_pos(); anima.anima1("You flee successfully"); is_player_fled = true; Thread.Sleep(1000); action_box_resetter(); action_box_pos() ;break;
                        default: action_box_resetter(); action_box_pos(); anima.anima1("You fail to flee"); break;
                    }
                    break;
                }

                if (is_player_fled == true){
                    is_player_fled = false;
                    break;

                }
                // HP and stats visualization
              
                if (a <= 0 && Player.health >0){
                    Enemy.En_alive = false;
                    action_box_resetter(); action_box_pos();
                    anima.anima1("Enemy defeated . . . . . ");
                    healthBar.Battle(a,b,pl_actions,d,c,cc);
                }
                else if (Player.battle_health <= 0 && a >0){
                    healthBar.Battle(a,b,pl_actions,d,c,cc);
                    action_box_resetter(); action_box_pos();
                    anima.anima1("Fail - - "); // 
                    action_box_pos_s2();
                    anima.anima1("You have been defeated . . . . .");
                    Player.Pl_alive = false;
                    Player.health -= 1; // Lessens the player overall health count out of maximum value 
                    Console.Title = $"HP {Player.health}";
                    Console.Clear();
                    layout.border_layout();
                    anima.anima1($"You have \x1b[31m{Player.health}\x1b[0m health remaining");
                    is_pl_defeated = true;
                }
                else if (a <= 0 && Player.health <= 0){
                    action_box_resetter(); action_box_pos();
                    Thread.Sleep(2000);
                    anima.anima1("Draw.......................");

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.White;
              
                
                

                Console.ResetColor();
            }
            
            // Player and enemy attribute resetter
            Player.battle_health = 50;
            Player.Pl_alive = true;
            Enemy.En_alive = true;

            action_box_pos();

        }
        public static void Boss_battle(int a, int b,int c, int d, int e, string cc){ // Enemy-- Where a = for the enemy health ||| b is for the enemy damage ||| c is for the enemy dodge rate ||| d is for the enemy attack rate || e is for the enemy miss rate
         
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor= ConsoleColor.DarkCyan;
           layout.Box_Generator(34,2,4,80);
           Console.ResetColor();

            while ( Player.Pl_alive== true && Enemy.En_alive == true){
                Random dmg_e = new Random();
                int en_actions = dmg_e.Next(1,100); // Random Percentage
                int pl_actions = dmg_e.Next(1,100); // Random Percentage 
                int en_attack = dmg_e.Next(1,3); // Random attack attributer 
                int pl_attack = dmg_e.Next(1,3); // Random attack attributer
                int en_miss_chances = dmg_e.Next(1,100);
                int player_flee = dmg_e.Next(1,100);
                bool is_player_fled = false;

                

                // HP Visualization
                healthBar.Battle(a,b,pl_actions,d,c,cc);
              
               
                Thread.Sleep(5);

            
                // Battle event
                bool enemy_dodge = false;
                 // needed to be assigned so the enemy can also miss an attack bay 30 percent or depends on the enemy algorithm
               

                system_selection.sel_2_battle("Attack","Dodge","Flee"); // Called for the selection
                switch(system_selection.battle_sel_option){

                    case 1: // Player attack choice

                   
                        action_box_resetter(); action_box_pos(); anima.anima1("You choose to attack");
                        switch(en_actions <c? "attack" : en_actions >d? "dodge": "attack" ){ // Random enemy response
                            case "attack":  
                            if (enemy_dodge == false){a -= Player.damage*pl_attack; action_box_resetter(); action_box_pos(); Console.Write("You hit the enemy !!!"); healthBar.Battle(a,b,pl_actions,d,c,cc); }// Player attack
                            if(en_miss_chances>e){ Player.battle_health -= b  *en_attack; action_box_resetter(); action_box_pos(); anima.anima1("The enemy manages to retaliate"); healthBar.Battle(a,b,pl_actions,d,c,cc);  }//Enemy retalliate
                            else if(en_miss_chances < e){action_box_resetter(); action_box_pos(); anima.anima1("The enemy attack but misses"); Thread.Sleep(1000);}
                           
                            break; // enemy attack
                            case "dodge": enemy_dodge = true; action_box_resetter(); action_box_pos(); Thread.Sleep(1000); anima.anima1("Enemy dodged your attack and retaliates"); Player.battle_health -= b  *en_attack;  healthBar.Battle(a,b,pl_actions,d,c,cc); break;
                    
                         }
                          if (enemy_dodge == true) { enemy_dodge = false; }
                          
                    break;

                    case 2: // Player dodge choice 
                        switch (pl_actions <60? "Dodge" : pl_actions > 60?"Fail": "Dodge"){
                            case "Dodge": action_box_resetter(); action_box_pos(); Console.WriteLine("you dodged the enemy");break;
                            case "Fail": action_box_resetter(); action_box_pos();anima.anima1("You failed to dodge");  Player.battle_health -= b  *en_attack; break; 
                        }
                     break;
                    case 3: action_box_resetter(); action_box_pos(); anima.anima1("You tried to flee . . . . . . "); Thread.Sleep(500);

                    switch (player_flee < 10? "flee" : "fail"){
                        case "flee": action_box_resetter(); action_box_pos(); anima.anima1("You flee successfully"); is_player_fled = true; Thread.Sleep(1000); action_box_resetter(); action_box_pos() ;break;
                        default: action_box_resetter(); action_box_pos(); anima.anima1("You fail to flee"); break;
                    }
                    break;
                }

                if (is_player_fled == true){
                    is_player_fled = false;
                    break;

                }
                // HP and stats visualization
              
                if (a <= 0 && Player.health >0){
                    Enemy.En_alive = false;
                    action_box_resetter(); action_box_pos();
                    anima.anima1("Enemy defeated . . . . . ");
                    healthBar.Battle(a,b,pl_actions,d,c,cc);
                }
                else if (Player.battle_health <= 0 && a >0){
                    healthBar.Battle(a,b,pl_actions,d,c,cc);
                    action_box_resetter(); action_box_pos();
                    anima.anima1("Fail - - "); // 
                    action_box_pos_s2();
                    anima.anima1("You have been defeated . . . . .");
                    Player.Pl_alive = false;
                    Player.health -= 1; // Lessens the player overall health count out of maximum value 
                    Console.Title = $"HP {Player.health}";
                    Console.Clear();
                    layout.border_layout();
                    anima.anima1($"You have \x1b[31m{Player.health}\x1b[0m health remaining");
                    is_pl_defeated = true;
                }
                else if (a <= 0 && Player.health <= 0){
                    action_box_resetter(); action_box_pos();
                    Thread.Sleep(2000);
                    anima.anima1("Draw.......................");

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.White;
              

                Console.ResetColor();
            }
            
            // Player and enemy attribute resetter
            Player.battle_health = 50;
            Player.Pl_alive = true;
            Enemy.En_alive = true;

            action_box_pos();

        }
    }
}