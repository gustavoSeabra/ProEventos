import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  mostrarImagem = false;
  private _filtroLista = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(value): this.eventos;
  }

  constructor(private evento: EventoService) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {

    this.evento.getEventos().subscribe({
      next: ((response) => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos
      }),
      error: ((error) => console.log(error))
    });
  }

  public alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local:string; }) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLowerCase().indexOf(filtrarPor) !== -1
    )
  }
}
