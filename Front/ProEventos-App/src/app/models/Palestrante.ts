import { Evento } from './Evento';
import { RedeSocial } from './RedeSocial';

export interface Palestrante {
  id: number;
  miniCurriculo: string;
  nome : string;
  imagemURL : string;
  telefone : string;
  email : string;
  redesSociais: RedeSocial[];
  palestrantesEventos: Evento[];
}
