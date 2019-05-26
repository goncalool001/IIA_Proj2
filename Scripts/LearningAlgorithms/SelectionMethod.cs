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

    public Individual torneio(List<Individual> pop,int populationSize,int tournSize,bool elitist)
    {
        Individual best = null;
        Individual ind;
        
        int n_start;

        if (elitist)
        {
            n_start = 1;
        }
        else
        {
            n_start = 0;
        }

        for (int i=1; i < tournSize; i++)
        {
            int rand = UnityEngine.Random.Range(0, pop.Count);

            //Debug.Log("random: "+rand+" pop.count: "+ pop.Count +" psize: " +populationSize);
            ind = pop[rand];
            if( (best == null) || (ind.Fitness>best.Fitness)){
                best = ind;
            }
        }

        return best;
    }

}
