using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticIndividual : Individual {
    public List<Individual> population;
    private int n_pontos;

    public GeneticIndividual(int[] topology,int n_pontos) : base(topology) {
        this.n_pontos = n_pontos;
	}

    public override void Initialize()
        {
            for (int i = 0; i < totalSize; i++)
            {
                genotype[i] = Random.Range(-1.0f, 1.0f);
            }
        }


    public override void Crossover (Individual partner, float probability){
        if (Random.Range(0.0f, 1.0f) < probability)
        {
            List<int> gen_list = new List<int>();

            for (int i = 0; i < n_pontos; i++)
            {
                gen_list.Add(Random.Range(0, totalSize));
            }

            gen_list.Sort();
            bool cross = false;
            for(int i = 0,j=0; i < totalSize; i++)
            {
                if(j<gen_list.Count && gen_list[j] == i)
                {
                    cross = !cross;
                    j++;
                }
                if (cross) // se existiu crossover
                {
                    genotype[i] = ((GeneticIndividual)partner).genotype[i];
                }
            }
        }
	}

	public override void Mutate (float probability)
	{
        for (int i = 0; i < totalSize; i++)
        {
            if (Random.Range(0.0f, 1.0f) < probability)
            {
                genotype[i] = Random.Range(-1.0f, 1.0f);
            }
        }
    }

	public override Individual Clone ()
	{
		GeneticIndividual new_ind = new GeneticIndividual(this.topology, this.n_pontos);

		genotype.CopyTo (new_ind.genotype, 0);
		new_ind.fitness = this.Fitness;
		new_ind.evaluated = false;

		return new_ind;
	}

}
