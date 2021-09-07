import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];

  show = true;

  private _filtroLista = '';

  public eventosFiltrados: any = [];

  public get filtroLista() {
    return this._filtroLista;
  }
  public set filtroLista(value) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtroLista: string): any {
    filtroLista = filtroLista.toLocaleLowerCase();
    return this.eventos.filter(
      (evento:{ tema: string; local: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtroLista) !== -1
      || evento.local.toLocaleLowerCase().indexOf(filtroLista) !== -1);
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{
    this.http.get("https://localhost:5001/api/evento").subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = response
      },
      error => console.log(error)
    );
  }

  showImage(){
    this.show = !this.show;
  }
}
