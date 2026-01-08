.PHONY: default docker-build kind-load

default: docker-build

docker-build:
	docker build . -t directory-proxy

kind-load:
	kind load docker-image directory-proxy --name $(if $(CLUSTER_NAME),$(CLUSTER_NAME),kind)

k3d-load:
	k3d image import directory-proxy -c $(if $(CLUSTER_NAME),$(CLUSTER_NAME),k3s-default)