//     This code was generated by a Reinforced.Typings tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.

import { CoronarographieDTO } from './coronarographie.dto';
import { DescriptionDTO } from './description.dto';

export class LesionDTO
{
 public Id: number;
 public TypeLesion: string;
 public Degre: number;
 public FluxTIMI: number;
 public CoronarographieId: number;
 public Coronarographie: CoronarographieDTO;
 public DescriptionId: number;
 public Description: DescriptionDTO;
}