/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/


namespace UnityGameTemplate
{
    public static class UGT_GameSetup
    {
        public static class General
        {
            public const string WEB_URL = "http://manuelrodriguezmatesanz.com";
        }

        public static class Animations
        {
            public const string ATTACK = "Attack ";
        }

        public static class PlayerPrefs
        {
            public const string LAST_LANGUAGE = "CPG_LastLanguagePP";
        }

        public static class Tags
        {
            public const string PLAYER = "Player";
            public const string ENEMY = "Enemy";
        }

        public static class Game_Settings
        {
            /// <summary>
            /// We want a binary JSON? If not encrypted, can be easily modified using Visual Code
            /// </summary>
            public const bool USE_BINARY_SAVE_FILES = false;
            /// <summary>
            /// Encrypt the save file using DES Encryption? The best option on final build is 
            /// encrypt and use binary - It will be a "double trouble" file! 
            /// </summary>
            public const bool ENCRYPT_SAVE_FILES = false;

        }

        public static class Inventory
        {
            /// <summary>
            /// How many objects we can store in the inventory
            /// </summary>
            public const int INVENTORY_LIMIT = 999;
            /// <summary>
            /// Max quantity of each object
            /// </summary>
            public const int QUANTITY_LIMIT = 99;
        }
    }

}
