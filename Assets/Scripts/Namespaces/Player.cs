using UnityEngine;

namespace P
{
    //namespace Pelaaja (voi olla sisäkkäin,
                    //silloin Using P.Pelaaja
    //{
        public class Player
        {     
        public Player()  
        {   
            Debug.Log("Player-luokasta luotiin olio ja sen konstruktoria kutsuttiin");
        }
        public Player(int x, int xxx=4)
        {
            Debug.Log("Player-luokasta luotiin olio ja sen konstruktoria kutsuttiin");
        }
        public Player(int x, double d)
        {
            Debug.Log("Player-luokasta luotiin olio ja sen konstruktoria kutsuttiin");
        }

        public void PrintHello()
        {
            Debug.Log("Hello!");
        }

        public void PrintHello(int x=5)
        {

        }
        }
    //}
}
