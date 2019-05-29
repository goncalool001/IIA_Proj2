using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;




public class SelectionMethod
{
    public SelectionMethod()
    { 
    }
       
    //override on each specific selection class
    public List<Individual> aux;
   
    //https://cstheory.stackexchange.com/questions/14758/tournament-selection-in-genetic-algorithms

    public Individual torneio(List<Individual> pop,int tournSize)
    {
        Individual best = null;
        Individual ind;
        

        for (int i=1; i < tournSize; i++)
        {
            int rand = UnityEngine.Random.Range(0, pop.Count); //gera um número aleatório entre 0 e o maximo da população
         
            ind = pop[rand]; //vai buscar um individuo com esse random
            if( (best == null) || (ind.Fitness>best.Fitness)){ //encontra o melhor do torneio
                best = ind;
            }
        }

        return best;
    }

}
