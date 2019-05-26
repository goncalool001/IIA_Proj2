using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MetaHeuristic
{
    public float mutationProbability;
    public float crossoverProbability;
    public int tournamentSize;
    public bool elitist;
    public int n_pontos;

    public override void InitPopulation()
    {
        population = new List<Individual>();
        // jncor 
        while (population.Count < populationSize)
        {
            GeneticIndividual new_ind = new GeneticIndividual(topology, n_pontos);
            new_ind.Initialize();
            population.Add(new_ind); //gera população
        }
    }

    
    public override void Step()
    {   
        List<Individual> new_pop = new List<Individual>();


        updateReport(); //called to get some stats
        if (elitist)
        {
            GeneticIndividual melhor = (GeneticIndividual)overallBest.Clone();
            new_pop.Add(melhor); //coloca o melhor de sempre na populaçao
        }

        while (new_pop.Count < populationSize)
        {
            GeneticIndividual parent1 = (GeneticIndividual)selection.torneio(population, populationSize, tournamentSize, elitist); //torneio
            GeneticIndividual parent2 = (GeneticIndividual)selection.torneio(population, populationSize, tournamentSize, elitist);

            GeneticIndividual tmp1 = (GeneticIndividual)parent1.Clone(); 
            GeneticIndividual tmp2 = (GeneticIndividual)parent2.Clone();

            tmp1.Crossover(tmp2, crossoverProbability); // crossover em temporarios
            tmp2.Crossover(tmp1, crossoverProbability);

            GeneticIndividual child1 = tmp1;// apenas para clareza
            GeneticIndividual child2 = tmp2;

            child1.Mutate(mutationProbability);//mutaçoes 
            child2.Mutate(mutationProbability);

            new_pop.Add(child1);
            new_pop.Add(child2);

        }
        population = new_pop;
        /*
        float maximum = population[0].Fitness;
        for(int i = 0; i < population.Count - 1; i++)
        {
            if (population[i].Fitness > maximum)
            {
                maximum = population[i].Fitness;
            }
        }

        Debug.Log("Max: " + maximum);
        */

        generation++;//passa para a próxima geração
    }
}
