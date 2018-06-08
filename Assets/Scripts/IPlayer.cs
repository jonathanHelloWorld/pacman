using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer  {

    void Movimentacao();
    bool FoiAtacado(IEnemy enemy);
    void TentarComer(IEnemy alvo);
    void Morreu();
    bool Nasceu();

}
