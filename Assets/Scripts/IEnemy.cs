using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IEnemy  {

    bool Vuneravel();
    bool Morreu();
    bool Nasceu();
    void Andar();
    void Atacar();


}
