using player;


namespace enemy{ // sets the enemy damage
    class Enemy{

        public static bool En_alive = true;
        //public static bool ene_dmg = false;
        public static void enemy_damage(){
            // DMG 
            Player.health -= 5;
        }
        public static void Ogre(){
            Player.health -= 10;
        }
        public static void Wolf(){
            Player.health -= 15;
        }
        public static void Ghost(){
            Player.sanity -= 20;
        }
    }
    class Enemy_Health{

       public static int Wolf_Health = 30;
       public static int Wolf_Damage = 5;

    }


}