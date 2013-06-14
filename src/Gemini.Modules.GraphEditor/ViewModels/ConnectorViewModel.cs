﻿using System;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

namespace Gemini.Modules.GraphEditor.ViewModels
{
    public enum ConnectorDataType
    {
        
    }

    public abstract class ConnectorViewModel : PropertyChangedBase
    {
        public event EventHandler PositionChanged;

        private readonly ElementViewModel _element;
        public ElementViewModel Element
        {
            get { return _element; }
        }

        private readonly BindableCollection<ConnectionViewModel> _connections;
        public IObservableCollection<ConnectionViewModel> Connections
        {
            get { return _connections; }
        }

        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }

        private readonly Color _color = Colors.Black;
        public Color Color
        {
            get { return _color; }
        }

        private Point _position;
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
                NotifyOfPropertyChange(() => Position);
                RaisePositionChanged();
            }
        }

        public abstract ConnectorDirection ConnectorDirection { get; }

        protected ConnectorViewModel(ElementViewModel element, string name, Color color)
        {
            _element = element;
            _name = name;
            _color = color;
            _connections = new BindableCollection<ConnectionViewModel>();
        }

        private void RaisePositionChanged()
        {
            var handler = PositionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}