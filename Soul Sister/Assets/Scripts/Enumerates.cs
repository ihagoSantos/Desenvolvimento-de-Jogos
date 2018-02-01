using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumerates {

    public enum estadoDeVida { Vivo, Morto };

    public enum estadoComportamento {IDLE,PATRULHAR,SEGUIR,FUGIR,ATACAR,VOLTARPISICAOINICIAL};

    public enum seguir { SIMPLES};

    public enum patrulhar { LINHARETA};

    public enum tipoCriatura { INIMIGO,PLAYER};

}
