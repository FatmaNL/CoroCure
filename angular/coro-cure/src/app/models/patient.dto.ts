//     This code was generated by a Reinforced.Typings tool. 
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

import { InterventionMedicaleDTO } from './intervention.dto';

export class PatientDTO
{
 public Id: number;
 public Nom: string;
 public Prenom: string;
 public Tel: string;
 public NSS: string;
 public Adresse: string;
 public DateNaissance: any;
 public Sexe: string;
 public InterventionMedicales: InterventionMedicaleDTO[];
}
