# Crear imagen del proyecto
> docker build -t javiertunoque/venta-aplicacion:1.0 .

# Crear namespace en AKS
> kubectl apply -f namespace.yaml

# Crear el archivo deployment y ejecutar en AKS
> kubectl apply -f deployment.yaml -n venta-aplicacion

# ejecutar el pod
> kubectl port-forward <Nombre-POD> 9093:80
> Ejemplo:
> kubectl port-forward pods/venta-aplicacion-fcb564f97-qrvb4 9093:80
  kubectl port-forward pods/web-ninx-demo01-6556d69757-9lcfg 9033:80

kubectl port-forward services/almacen-api 9013:80 --namespace=almacen

# Crear el archivo services y ejecutar en AKS
> kubectl apply -f service.yaml -n venta-aplicacion